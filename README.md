# Задание 1

# Таблицы:
### Структура таблицы: `ValueEntities`

| Поле       | Тип данных | Ограничения     | Описание                |
|------------|------------|-----------------|-------------------------|
| `Index`    | INTEGER    | PRIMARY KEY     | Уникальный идентификатор |
| `Code`     | INTEGER    | NOT NULL        | Код значения            |
| `Value`    | TEXT       | NULLABLE        | Строковое значение      |

### Структура таблицы: `RequestLogs`
| Поле        | Тип данных   | Ограничения     | Описание                          |
|-------------|--------------|-----------------|-----------------------------------|
| `Id`        | INTEGER      | PRIMARY KEY     | Уникальный идентификатор запроса |
| `Method`    | TEXT         | NOT NULL        | HTTP-метод     |
| `StartDate` | DATETIME     | NOT NULL        | Время начала запроса             |
| `EndDate`   | DATETIME     | NOT NULL        | Время завершения запроса         |
| `Path`      | TEXT         | NOT NULL        | Route запроса             |
| `StatusCode`| INTEGER      | NOT NULL        | HTTP-статус ответа                |

# Структура проекта
Application/             // Бизнес-логика приложения
  Dtos/                  
  Extension/            
  Interfaces/            
  Models/                
  Services/    
  
Domain/
  Entities/              // Сущности
  
Infrastructure/          // Слой взаимодействия с бд
  Database/             
  Extension/             
  
TestTask/ (API)          // WEB-сервис
  Controllers/           
  Middleware/            
  appsettings.json       
  Program.cs             
