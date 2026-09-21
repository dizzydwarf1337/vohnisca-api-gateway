# Agents — vohnisca-api-gateway

## Identity
Единственная точка входа со стороны фронтенда. Принимает REST, транслирует в **JSON-RPC 2.0**
(EdjCase) к downstream-сервисам (auth/user/mail). Здесь источник правды по контракту ответа
`ApiResponse<T>` и по RPC-клиентам к сервисам.

## Stack
- C# **.NET 9**, Clean Architecture, CQRS через **MediatR**.
- JSON-RPC клиент — **EdjCase.JsonRpc.Client**.
- Слои: `vohnisca-api-gateway/` (Web API, Controllers, DI) · `Application/` (Commands/Queries, интерфейсы RPC + DTO) · `Infrastructure/` (реализации RPC-клиентов).

## Read order
1. В мета-репо: `.claude/rules/dotnet-preflight.md` — общие .NET-конвенции.
2. Этот файл.
3. Подробный разбор правил (архив): `workspace/drafts/API-GATEWAY-AGENTS.md` в мета-репо.

## Verification
- Сборка: `dotnet build vohnisca-api-gateway/vohnisca-api-gateway.sln`
- Тестов пока нет (проект `*.Tests` планируется). «Зелёно» = чистая сборка.

## Эталон
- Команда целиком: `vohnisca-api-gateway/Application/Commands/Public/Auth/Login/` (Command + Handler + Validator).
- RPC-клиент к сервису: `vohnisca-api-gateway/Infrastructure/RpcClients/AuthRpcClient.cs`.
- Контроллер: `vohnisca-api-gateway/vohnisca-api-gateway/Controllers/Public/Auth/AuthController.cs`.
- Новую команду/клиент/контроллер делать по образцу этих.

## Локальные конвенции
- **Иерархия Request** задаёт авторизацию (не `[Authorize]`): `PublicRequest` (login/sign-up),
  `UserRequest` (`IUserRequest`), `AdminRequest`/`SuperadminRequest`. Pipeline: Validation →
  Authorization → ExceptionHandling → Handler.
- **`Token`/`UserId` — `[JsonIgnore]`** на авторизованных Request (защита от подмены через body).
- **Выбор базового RPC-клиента:** `LaravelRpcClient` (плоские params, для auth) vs `DotnetRpcClient`
  (params обёрнуты в `request`, для user/mail). RPC-методы — PascalCase без точек.
- Поле массива в RPC-DTO называется `Data`. `RpcResult<T>` → `ApiResponse<T>` только через `.ToApiResponse(...)`.
- **`ApiResponse<T>` (isSuccess/value/error/statusCode) не менять без синхронизации с фронтом.**
- Порты downstream — в `appsettings.Development.json` (`RpcServices`). CORS — только `localhost`.
- Известный долг: авторизация `AdminRequest`/`SuperadminRequest` в `AuthorizationBehavior` не полна.

## Коммит-граница
Репозиторий `dizzydwarf1337/vohnisca-api-gateway`, дефолтная ветка `main`. Коммиты уходят сюда, не
в мета-корень. Ветка текущей работы по воркспейсу: `core/implement-api-gateway-workspace`.
