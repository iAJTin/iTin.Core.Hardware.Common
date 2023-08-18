# IPropertyKey interface

Defines a value that contains the detailed information of a writer.

```csharp
public interface IPropertyKey
```

## Members

| name | description |
| --- | --- |
| [PropertyId](IPropertyKey/PropertyId.md) { get; } | Gets a value that represents a [`StructureId`](./IPropertyKey/StructureId.md) field from which the value is to be retrieved. |
| [PropertyUnit](IPropertyKey/PropertyUnit.md) { get; } | Gets a value that represents the unit in which the property is measured. |
| [StructureId](IPropertyKey/StructureId.md) { get; } | Gets a value that represents the structure from which the value is to be retrieved. |
| [GetPropertyDescription](IPropertyKey/GetPropertyDescription.md)() | Returns the property description. |
| [GetPropertyName](IPropertyKey/GetPropertyName.md)() | Returns the property name. |
| [GetPropertyType](IPropertyKey/GetPropertyType.md)() | Returns the property type. |

## See Also

* namespace [iTin.Core.Hardware.Common](../iTin.Core.Hardware.Common.md)

<!-- DO NOT EDIT: generated by xmldocmd for iTin.Core.Hardware.Common.dll -->