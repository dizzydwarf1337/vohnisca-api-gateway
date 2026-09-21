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
- Базовый класс по downstream-стеку: **`LaravelRpcClient`** (плоские params → auth-service) или
  **`DotnetRpcClient`** (params в обёртке `request` → user/mail).
- DTO результата лежат рядом с интерфейсом; поле массива — `Data`.

## Контракт наружу

`ApiResponse<T>` (`isSuccess`, `value`, `error`, `statusCode`) — общий с фронтендом. **Изменение —
только синхронно с `vohnisca-public-frontend`** (там RTK Query распаковывает value-тип).

## Внешние точки

Порты downstream — `appsettings.Development.json` (`RpcServices`) и env docker-compose
(`RpcServices__<Service>`). CORS — только `http(s)://localhost`.

## Известный долг

Авторизация `AdminRequest`/`SuperadminRequest` в `AuthorizationBehavior` не полна — расширять при
добавлении админ-функционала.
