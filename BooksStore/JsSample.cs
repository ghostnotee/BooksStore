using Microsoft.JSInterop;

namespace BooksStore;

public static class JsSample
{
    [JSInvokable("AddTwoNumbers")]
    public static int Sum(int firstNumber, int secondNumber)
    {
        return firstNumber + secondNumber; 
    }
}