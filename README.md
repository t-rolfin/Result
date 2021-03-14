# Structure of `Result`

Before to start to show you how to use this library I wanna to make you comfortable with the structure of the "Result" object.

The structure of the _generic version_ contains:
``` csharp
// contains information about result, like: code, message and the name of the result type
public IMetaResult MetaResult;

// it's the value you wanna to return, it can be null or any value type or reference type 
public T Value;

// will return a bool value that indicates if the result is a success one or not
public IsSuccess { get; private set; }
```

The result also contains several methods:

``` csharp

// returns the value type of the 'Value' property
public abstract Type GetValueType();

// those helps you to customize information about result
public Result<T> With<CType>();
public Resutl<T> With<CType>(string message);
public Result<T> With(string message);

```


# How to use

To create a result you have plenty of options.

### One option is constructors:

* _default constructor_

``` csharp
Result<CustomModel> result = new Result<CustomModel>();
```
This will return a result with "Value" of type `CustomModel`, but this will be null. The property IsSuccess is setted as `true` and the MetaResult is setted
as [Ok](https://github.com/t-rolfin/Result/blob/main/src/Rolfin.Result/MetaResults/Ok.cs).

* _constructor with one parameter_

``` csharp
Result<CustomModel> result = new Result<CustomModel>(new CustomModel())
```
This one will return the same result like previously but property "Value" will be set with given value.

### Other option is static methods:

The available options are:

``` csharp
public static Result<T> Success();
public static Result<T> Success(T result);
public static Result<R> Success<R>(R result);

public static Result<T> Invalid();
public static Result<T> Invalid(string message);
public static Result<T> Invalid(T result);
```
The "Success" methods will return a MetaResult of type Ok, while the "Invalid" methods will return [NotFound](https://github.com/t-rolfin/Result/blob/main/src/Rolfin.Result/MetaResults/NotFound.cs).

# Customize the "MetaResult"

The "MetaResult" property will provide information like code, message and name of the result type.

The structure of this looks like:
``` csharp
public int Code { get; }
public string Name { get; }
public string Message { get; set; }
```

[Here](https://github.com/t-rolfin/Result/tree/main/src/Rolfin.Result/MetaResults) can be found the default MetaResult types.

Also you can create your own types with the help of `IMetaResult` inferface.

The method `With` is another option to customize your meta result.

Examples:
* Return different messages with the same type of MetaResult
``` csharp
var result = Result<CustomModel>.Invalid().With("Different message.");
```
_and_
``` csharp
var result = Result<CustomModel>.Invalid().With("Other message.");
```
Both will return an `NotFound` MetaResult with different messages. 

* Return other MetaResult them the default version
``` csharp
var result = Result<CustomModel>.Invalid().With<MyNewError>();
```
**Be careful** `MyNewError` should implement `IMetaResult` interface.

* Can go farther and return custom MetaResult with other message then default one
``` csharp
var result = Result<CustomModel>.Invalid().With<MyNewError>("Other message then default one.");
```
**All above examples are available for every static method.**

I hope you enjoy playing with this library.
