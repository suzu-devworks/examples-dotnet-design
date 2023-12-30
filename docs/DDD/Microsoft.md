# Microsoft (.NET Microservices: Architecture for Containerized .NET Applications)

## References

* https://docs.microsoft.com/ja-jp/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/
* https://github.com/dotnet-architecture/eShopOnContainers/tree/main/src/Services/Ordering/Ordering.Domain

## Words

### CQS/CQRS

CQRS は、データを読み取りと書き込みのモデルを分離するアーキテクチャ パターンです。

システムの操作は 2 つの別のカテゴリにはっきりと分けることができるということです。
* Query: これらのクエリによって結果が返され、システムの状態は変更されません。また、副作用はありません。
* Command: これらのコマンドによってシステムの状態が変更されます。

CQS はシンプルな概念です。つまり、同じオブジェクト内のメソッドはクエリまたはコマンドである、というものです。

### Entity

エンティティは、ドメイン オブジェクトを表すもので、主にその ID、継続性、および永続化によって時間とともに定義されます。エンティティを構成する属性によってのみ定義されるわけではありません。 Eric Evans 氏が言うように、"主にその ID で定義されるオブジェクトは、エンティティと呼ばれます"。 エンティティは、モデルの基礎となるため、ドメイン モデルで非常に重要です。 したがって、エンティティは、慎重に識別し、設計する必要があります。

エンティティの ID は、複数のマイクロサービスまたは有界コンテキストを横断できる。

### Value Object

値オブジェクトは、ドメインのアスペクトを記述する概念 ID を持たないオブジェクトです。 これは、一時的にしか関係しない設計要素を表すためにインスタンス化するオブジェクトです。 関心を持つ必要があるのは、それが "誰" であるのかではなく、"何" であるのかという点です。

EF Core 2.0 以降のバージョンには、後で詳しく説明しているように、値オブジェクトを処理しやすくする Owned Entities が含まれます。

### Aggregate

より細かな DDD 単位は集約であり、まとまりのある単位として処理できるエンティティとビヘイビアーのクラスターまたはグループが記述されています。
通常は、必要なトランザクションに基づいて集約を定義します。

### Aggregate Root or Root Entity

集約は、集約ルートという 1 つ以上のエンティティから構成されています (集約ルートは、ルート エンティティまたはプライマリ エンティティとも呼ばれます)。 また、集約は、複数の子エンティティと値オブジェクトを持つことができ、すべてのエンティティとオブジェクトが連携して、必要なビヘイビアーやトランザクションを実装しています。

集約ルートの目的は、集約の一貫性を維持することです。


## Enumeration Class

Use enumeration classes instead of enum types

* 列挙型の問題
  * 列挙に関連する動作がアプリケーション全体に散らばる。各所にswitchステートメントが増えることになる。
  * 新しい列挙値の追加にリファクタリング「ショットガン手術」が必要
    * 列挙の追加で 全てのswitch文の default: を確認。
  * 列挙は、オープンクローズの原則に従っていません
