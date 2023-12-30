# Anderson (Piikokku Anderson's DDD)

## References

* https://anderson02.com/ddd-menu/

## Words

### Entity

Entityは意味のあるひとかたまりのデータとして扱います。データベースの1行分のデータと考えるといいと思います。
Entityの決め事としては，「一意」であるということです。同じEntityが複数あってもその一つを特定できる必要があります。

### ValueObject

* 不変クラスとします。値はすべてコンストラクタで設定します。
* 継承させないようにsealedクラスにします。
* 同じ値のValueObjectは同じものと判断します。
* 一意性がない

### Repository

* 外部と接触するためのインターフェースとして実装します.
* インターフェースはDomain層に配置します。
* 実装はInfrastructure層で行います。

### Factory

* Repositoryインスタンスの生成はFactoryで行います。
* FactoryはInfrastructure層に配置します。
* RepositoryインスタンスはFactory以外から生成できないようにアクセス修飾子はInternalにします。
* Mock(Fake)とDriverとの切り替えをFactoryで行う

