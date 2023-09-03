# dotnet-webapi-architecture

## Layered Architecture

```mermaid
graph TD;
    c[Controller];
    s1[Service A];
    s2[Service B];
    c-- 単一Serviceのみの場合 -->s1;
    c-- 複数のServiceが必要な場合 -->Logic;
    Logic-->s1;
    Logic-->s2;
    repoA[[Repository A]];
    repoB[[Repository B]];
    ds1[(DataBase)];
    ds2[(External API)];
    s1-->repoA;
    s1-->repoB;
    repoA-->ds1;
    repoB-->ds2;
```
