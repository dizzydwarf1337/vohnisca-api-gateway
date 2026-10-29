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

- Workshop service (`WorkshopRpcClient`, `Controllers/User/WorkshopService`, `RpcServices:WorkshopService`):
  свои заклинания и предметы — `POST spells`, `PUT spells/{id}`, `PUT spells/{id}/visibility`,
  `DELETE spells/{id}` и то же для `items` (multipart: `payload` + `file` для иконки).
- Карты воркшопа: `GET maps?mine=`, `GET maps/{id}`, `POST maps`, `PUT maps/{id}`,
  `PUT maps/{id}/visibility`, `DELETE maps/{id}`, `PUT maps/{id}/levels/{levelId}` (имя),
  `PUT maps/{id}/levels/{levelId}/position`, `DELETE maps/{id}/levels/{levelId}`.
- NPC воркшопа: `GET npcs?mine=`, `GET npcs/{id}`, `POST npcs`, `PUT npcs/{id}`,
  `PUT npcs/{id}/abilities`, `PUT npcs/{id}/profile`, `PUT npcs/{id}/image` (multipart `file` /
  `remove`), `POST npcs/{id}/actions`, `DELETE npcs/{id}/actions/{actionId}`, `POST npcs/{id}/traits`,
  `DELETE npcs/{id}/traits/{traitId}`, `PUT npcs/{id}/visibility`, `DELETE npcs/{id}`.
- Стол и воркшоп (session service): `POST sessions/{id}/scene/map-level` (уровень карты на стол),
  `POST sessions/{id}/scene/save-to-map` (сцена в уровень своей карты),
  `POST sessions/{id}/scene/workshop-npcs` (NPC воркшопа на клетку); у сцены — `source`
  (карта и уровень, только мастеру).
- Объявление заклинания NPC для Counterspell: `POST sessions/{id}/combat/{tokenId}/announce-spell`
  (`spellName`, `level`; мастер, в бою).
- Боевые действия: `grapple`, `shoveProne`, `shoveAway`, `release`, `bardicInspiration`,
  `turnUndead`, `fontToPoints` / `fontToSlot`; в `TakeCombatActionCommand` — `dc` (КС мастера
  для захвата NPC) и `level` (Font of Magic). `CastSpellCommand.metamagic`, `AttackCommand.brutal`.
- В виде персонажа — `metamagic`, `brutalStrike`, `brutalEffects`, у атак — `usesStrength`; у листа NPC — `creatureType`,
  `UpdateSceneTokenCommand.creatureType`.
- `GET campaigns/{campaignId}/sessions` — прошлые сессии кампании и итоги (участникам кампании).

### Changed
- Каталог правил (`races`, `classes`, `backgrounds`, `features`, `items`, `spells` — списки и
  карточки) читается из workshop service; маршруты и ответы прежние. `spells/{id}/info` и
  `items/{id}/info` остались в character service.
- Ошибки character service отображаются в корректные HTTP-статусы; в ответе видна причина
  ошибки RPC-транспорта.
- Session service локально на порту 5060 (5050 занят pgAdmin).
