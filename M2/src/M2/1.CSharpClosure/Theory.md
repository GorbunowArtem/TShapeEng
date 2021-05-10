## Closure is a first-class function with free variables that are bound in the lexical environment.
### First-class function
is one that may participate as a normal data, i.e. be created literally at runtime, be passed as an argument, or be returned as a value from another function.
In C# language it is implemented via anonymous method:
  ```c#
    Func<string,string> myFunc = delegate(string var1)  
    {   
        return "some value";    
    };
    ```
Or we can use lambda functions:
   ```c#
       Func<string,string> myFunc = var1 => "some value";
   ```
When a function is passed as an argument, it’s called a “funarg” — an abbreviation of the functional argument concept.

In turn, a function which accepts the “funarg” is called a higher-order function (HOF) or, closely to mathematics, an operator.
                                       
### Funarg problem
The funarg problem is divided into two sub-problems which are directly related with concepts of scope, environments and closures.
A function which returns another function is called a function with a functional value (or a function-valued function).

- Upward funarg problem corresponds to the complexity of returning an inner function to the outside (upward) — i.e. how can we implement the returning of the function if this function uses free variables of the parent environment in which it’s created?
- Downward funarg problem corresponds to the ambiguity of the variable name resolution when we pass a function which uses free variables as an argument to another function. In which scope these free variables should be resolved — in the scope of the function definition or in the scope of the function execution?
### Free variable
is a variable which is used by a function, but is neither a parameter, nor a local variable of the function.
    
```c#
    private static Func<int> GetAFunc()
		{
			var freeVariable = 1;
			
			return toAdd =>
			{
				return freeVariable;
			};
		}
   ```                                                  
  
  In example above `freeVariable` is free variable for anonymous lambda method.

### Lexical environment
The commonly held minimalist definition of the lexical environment defines it as a set of all bindings of variables in the scope, and that is also what closures in any language have to capture. However the meaning of a variable binding also differs. In imperative languages, variables bind to relative locations in memory that can store values. Although the relative location of a binding does not change at runtime, the value in the bound location can. In such languages, since closure captures the binding, any operation on the variable, whether done from the closure or not, are performed on the same relative memory location. This is often called capturing the variable “by reference”.

On the other hand, many functional languages, such as ML, bind variables directly to values. In this case, since there is no way to change the value of the variable once it is bound, there is no need to share the state between closures—they just use the same values. This is often called capturing the variable “by value”. Java’s local and anonymous classes also fall into this category—they require captured local variables to be final, which also means there is no need to share state.

There are at least two kind of lexical environments, “capture by reference” and “capture by value”. In Java, it’s “capture by value”. However, in C# and Python, it’s “capture by reference”.
