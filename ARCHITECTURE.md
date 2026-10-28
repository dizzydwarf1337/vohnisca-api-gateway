# Architecture — vohnisca-api-gateway

Читать перед нетривиальными правками. Обзор слоёв и сквозных потоков; детали конвенций — в `AGENTS.md`.

## Слои

```
vohnisca-api-gateway/            Web API: Controllers, DI, CORS, Program.cs
Application/                     Commands/Queries, MediatR-инфра (behaviors),
                                 интерфейсы RPC-клиентов + их DTO
Infrastructure/                  реализации RPC-клиентов, ICurrentUserService
```

Зависимости направлены внутрь: Web API → Application → (интерфейсы) ← Infrastructure.

## Поток запроса

```
HTTP (REST) → Controller → MediatR Send(Command)
  → ValidationBehavior → AuthorizationBehavior → ExceptionHandlingBehavior → Handler
  → RPC-клиент (JSON-RPC 2.0) → downstream-сервис
  → RpcResult<T> → .ToApiResponse(mapper, errorText) → ApiResponse<T> → HTTP
```

- **Авторизация задаётся типом Request**, не атрибутами: `PublicRequest` / `UserRequest` (`IUserRequest`)
  / `AdminRequest` / `SuperadminRequest`. Поведение решает `AuthorizationBehavior`.
- `Token`/`UserId` на авторизованных Request — `[JsonIgnore]` (не принимаются из body).

## RPC-клиенты

- Интерфейсы — `Application/Interfaces/RpcClients/`; реализации — `Infrastructure/RpcClients/`;
  регистрация — `HttpRpcClients.cs`.
- Базовый класс по downstream-стеку: **`LaravelRpcClient`** (плоские params → auth, campaign) или
  **`DotnetRpcClient`** (params в обёртке `request` → user, mail, character, session).

| Клиент | Сервис | Контроллеры |
|---|---|---|
| `AuthRpcClient` | auth (Laravel) | `Public/Auth` |
| `UserRpcClient` | user (.NET) | `User/UserService` (профиль, друзья, заявки) |
| `MailRpcClient` | mail (.NET) | `Admin/Mail` |
| `CampaignRpcClient` | campaign (Laravel) | `User/CampaignService` (кампании, главы, заметки) |
| `CharacterRpcClient` | character (.NET) | `User/CharacterService` (персонажи; сведения о заклинании и предмете `/info`) |
| `WorkshopRpcClient` | workshop (.NET) | `User/WorkshopService` (каталог правил: расы, классы, предыстории, фичи, предметы, заклинания; свои заклинания и предметы; карты и NPC) |
| `SessionRpcClient` | session (.NET, в репо character-service) | `User/SessionService` (сессия, сцена, бой, кубы, игровое время) |
- DTO результата лежат рядом с интерфейсом; поле массива — `Data`.

## Контракт наружу

`ApiResponse<T>` (`isSuccess`, `value`, `error`, `statusCode`) — общий с фронтендом. **Изменение —
только синхронно с `vohnisca-public-frontend`** (там RTK Query распаковывает value-тип).

## Внешние точки

Порты downstream — `appsettings.Development.json` (`RpcServices`) и env docker-compose
(`RpcServices__<Service>`; воркшоп — `RpcServices__WorkshopService`, локально 5070). CORS —
только `http(s)://localhost`. Сервисы между собой говорят через RabbitMQ, не через gateway.

Хабы реального времени проксируются как есть (YARP, `Core/ServicesConfiguration/Proxy/HubProxy.cs`):
`/hubs/session` → session service (`RpcServices:SessionService`). Фронтенд по-прежнему ходит
только в gateway. Список RPC сессии и соответствующих маршрутов — в
`vohnisca-character-service/docs/SESSION-SERVICE.md`.

## Известный долг

Авторизация `AdminRequest`/`SuperadminRequest` в `AuthorizationBehavior` не полна — расширять при
добавлении админ-функционала.
