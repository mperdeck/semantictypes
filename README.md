Semantic Types
==============

Semantic Types help you reduce bugs and improve maintainability by letting the compiler ensure consistency in your code.

For example, instead of using a string everywhere to hold a email address, you create a new semantic type EmailAddress:
```csharp
string emailAddressStr = ... ;
EmailAddress emailAddress = new EmailAddress(EmailAddressDT);
```

The EmailAddress constructor ensures that the passed in value is a valid email address. If it is not valid, it throws an exception, so it fails hard and early.

Then where ever you use an email address, you use a EmailAddress, not a string. That gives you:
 
* **Type based on meaning, not on physical storage**: An EmailAddress is physically still a string. What makes it different is the way we think of that string - as an email address, not as a random collection of characters.
* **Type safe**: Having a distinct EmailAddress type enables the compiler to ensure you're not using some common string where a valid email address is expected - just as the compiler stops you from using a string where an integer is expected.
* **Guaranteed to be valid**: Because you can't create an EmailAddress based on an invalid email address, and you can't change it after it has been created, you know for sure that every EmaillAddress represents a valid email address.
* **Documentation**: When you see a parameter of type EmailAddress, you know right away it contain an email address, even if the parameter name is unclear. 
 
Documentation
============
[Introducing Semantic Types in .Net](http://www.codeproject.com/Articles/860646/Introducing-Semantic-Types-in-Net)


Installation
============

Install via NuGet:

```PM> Install-Package SemanticTypes```

Example
=======

Here is an example implementation of a Semantic type:

```csharp
public class EmailAddress : SemanticType<string>
{
	public static bool IsValid(string value)
	{
		return (Regex.IsMatch(value,
						@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
						@"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
						RegexOptions.IgnoreCase));
	}

	public EmailAddress(string emailAddress) : base(IsValid, typeof(EmailAddress), emailAddress) { }
}
```

And here is how you might use it:

```csharp
bool isValid = EmailAddress.IsValid("test@corp.com"); // True
EmailAddress EmailAddress = new EmailAddress("test@corp.com"); // Ok

bool isValid = EmailAddress.IsValid("not a valid email address"); // False
EmailAddress EmailAddress = new EmailAddress("not a valid email address"); // Throws exception
```

