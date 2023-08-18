# QueryPropertyResult class

Specialization of ResultBase interface. Where `T` is of type [`PropertyItem`](./PropertyItem.md). Represents result after query operation.

```csharp
public class QueryPropertyResult : ResultBase<PropertyItem>
```

## Public Members

| name | description |
| --- | --- |
| [QueryPropertyResult](QueryPropertyResult/QueryPropertyResult.md)() | The default constructor. |
| static [CreateErroResult](QueryPropertyResult/CreateErroResult.md)(…) | Returns a new [`QueryPropertyResult`](./QueryPropertyResult.md) with specified detailed error. (4 methods) |
| static [CreateSuccessResult](QueryPropertyResult/CreateSuccessResult.md)(…) | Returns a new success result. |
| static [FromException](QueryPropertyResult/FromException.md)(…) | Creates a new [`QueryPropertyResult`](./QueryPropertyResult.md) instance from known exception. (2 methods) |

## See Also

* class [PropertyItem](./PropertyItem.md)
* namespace [iTin.Core.Hardware.Common](../iTin.Core.Hardware.Common.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Core.Hardware.Common.dll -->