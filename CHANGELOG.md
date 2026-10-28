# Changelog — vohnisca-api-gateway

Формат — [Keep a Changelog](https://keepachangelog.com/ru/1.1.0/), версии — [SemVer](https://semver.org/lang/ru/).
Правится при нарезке релиза, а не в каждом feature-PR.

## [Unreleased]
### Added
- `AGENTS.md` — роутер репозитория для воркспейса Vohnisca.
- `ARCHITECTURE.md` — слои, поток запроса, RPC-клиенты, контракт `ApiResponse<T>`.
- Character service (`CharacterRpcClient`, `Controllers/User/CharacterService`): персонажи
  (создание по SRD 5.2 с выбором опций, level-up и мультикласс, ASI, подкласс, характеристики,
  заклинания, предметы, деньги, портрет, шаринг), каталог SRD 5.2, освобождение персонажа из
  зависшей сессии.
- Session service (`SessionRpcClient`, `Controllers/User/SessionService`): лобби и живая сессия,
  панель сессий, сцена (токены, туман, стены, двери, контейнеры и замки, местность, обзор и свет),
  кубы, бой (инициатива, атаки, заклинания, реакции, действия классов, снаряжение, броски
  предметов), отдых, игровое время и таймеры, прочность объектов и разрушаемые стены, материалы
  местности (вода, лёд, кустарник, масло).
- Сведения о заклинании и предмете вне сессии: `GET spells/{id}/info?characterId=`, `GET items/{id}/info`;
  варианты выбора при создании и level-up несут `spellId` / `itemId`.
- Каст заклинания с выбором бафа (`choice`); у эффектов заклинаний `choose`/`chooseFrom`, у листов — `effectChoices`.
- Прокси хаба `/hubs/session` в session service (YARP).
- `SetNoteColor`, доступы заметки и перенос главы в корень (campaign).

### Changed
- Ошибки character service отображаются в корректные HTTP-статусы; в ответе видна причина
  ошибки RPC-транспорта.
- Session service локально на порту 5060 (5050 занят pgAdmin).
