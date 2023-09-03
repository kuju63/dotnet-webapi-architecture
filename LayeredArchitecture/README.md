# LayeredArchitecture

## Class Diagram

```mermaid
classDiagram
class BookController
class IBookService
<<interface>> IBookService

class BookService

class IBookApi
<<interface>> IBookApi

class IHistoryRepository
<<interface>> IHistoryRepository
class HistoryRepository

class HistoryDbContext

IBookService <|-- BookService
IHistoryRepository <|-- HistoryRepository
BookController --> IBookService
BookService --> IBookApi
BookService --> IHistoryRepository
HistoryRepository --> HistoryDbContext
```
