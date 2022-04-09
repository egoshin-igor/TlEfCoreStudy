# TlEfCoreStudy

## Ветки

v1 - начальная версия проекта. Пустышка с моками.

v2 - конечная версия проекта с миграциями, ef core, unit of work с простымми crud-операциями.

## Основные термины и паттерны

**ORM** (Object-Relational Mapping)  объектно-реляционное  отображение , или преобразование. Абстракция при обращении к базе данных. Пример, Ef core.

**Repository** - паттерн, используемый для абстрагирования от механизма хранения объектов. Работа с объектами как с обычной коллекцией объектов. Клиентам не нужно беспокоиться как внутри устроена коллекция. Пример AuthorRepository.

**UnitOfWork** - паттерн, позволяющий завершать бизнесовые транзакции, фиксируя все изменения. В нашем случае вызов метода Commit сохранит все изменения, произошедшие во время транзакции. Например, добавление нового пользователя.

**Миграция** - автоматически-генерируемый файл, фиксирующий все изменения с нашими моделями. Выполнение миграции приведет к изменению нашей базы данных(указанной в connection string).

**Операции с миграциями.** Для того, чтобы создавать/выполнять/откатывать миграции нужно открыть Package manager console. В VS для этого нужно - нажать View -> Other windows -> Package manager console.
Основные операции:

- add-migration \<migration-name> - добавляет новую миграцию;
- update-database - выполняет все невыполненные миграции;
- update-database \<migration-name> - откат миграций до \<migration-name> невключительно;
- update-database 0 - откат всех миграций;
- remove-migration - удаление последней миграций;

**DbContext** - контекст нашей базы данных. В этом классе находятся применяемые конфигурации сущностей, доступ к сущностям через dbContext.Set\<Entity>(), коммит всех изменений в базу - dbContext.SaveChanges();

- Может работать с многими базами;
- DbContext - как база для нас будет;
- dbContext.Set\<Entity>() доступ к таблице с названием Entity;

**IEntityTypeConfiguration\<Entity>** - интерфейс, в реализации которого настраивается наша сущность для базы данных - длина строки, тип столбца у поля, внешние ключи, первичный ключ, индексы и т.п.

**Linq** (language integrated query)- язык запросов на уровне языка C#. Похож по синтаксису и терминам на SQL.
Linq запрос превращается в SQL-запрос, происходит выполнение запроса. Результат превращается в список объектов. Выполнение запроса не происходит пока не вызовится ToList(), FirstOrDefault(), Any() и асинхронные версии методов. Linq можно использовать не только через dbContext, а почти с любыми коллекциями.

- Пространстрова имен - `System.Linq`;
- `List<User> users = _dbContext.Set<User>().Where(e => e.Age >= 18).ToList();` - получить всех пользователей возраст которых больше или равно 18.
  Эквивалентно - `select * from [User] where Age >= 18`.
- `User user = _dbContext.Set<User>().FirstOrDefault(e => e.Id >= 5);` - получить пользователя Id которого равен 5.

## Зависимости

Microsoft.EntityFrameworkCore - зависимость, позволяющая использовать EfCore

Microsoft.EntityFrameworkCore.SqlServer - зависимость, позволяющая использовать MsSqlServer в EfCore

Microsoft.EntityFrameworkCore.Tools - зависимость, нужная для управления миграциями через Package manager console

## Домашнее задание

Переделать бэкэнд ToDo-приложения. Вместо голого sql-кода использовать linq. Создание таблиц и их изменение сделать через миграции.

Требования:

- миграции;
- linq вместо голых запросов;
- dto не используются в repository и в сервисах с логикой;
- Фиксирование изменений в базе происходит только через UnitOfWork;
- UnitOfWork  используется только на самых высоких уровнях использования - в контроллерах в данном случае.