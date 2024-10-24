namespace LeetCodeDailyProblems.Solutions;

internal class Solution1106 : Solution<string, bool>
{
    #region Algos
    private bool ParseBoolExpr(string expression)
    {
        int n = expression.Length;
        Stack<char> stack = new Stack<char>();

        for (int i = n - 1; i >= 0; i--)
        {
            char c = expression[i];
            if (c == ')' || c == 't' || c == 'f') stack.Push(c);
            else if (c == ',' || c == '(') continue;
            else
            {
                bool b;
                if (c == '!') b = !(stack.Pop() == 't');
                else if (c == '&')
                {
                    b = true;
                    while (stack.Count > 0 && stack.Peek() != ')')
                        b = ((stack.Pop() == 'f') ? false : true) && b;
                }
                else
                {
                    b = false;
                    while (stack.Count > 0 && stack.Peek() != ')')
                        b = ((stack.Pop() == 'f') ? false : true) || b;
                }

                stack.Pop();
                stack.Push(b ? 't' : 'f');
            }
        }

        return (stack.Pop() == 't');
    }

    private bool ParseBoolExprLINQ(string expression)
    {
        var stack = new Stack<char>();

        expression.Reverse()
                  .ToList()
                  .ForEach(c =>
                  {
                      if (c == ')' || c == 't' || c == 'f') stack.Push(c);
                      else if (c == '(' || c == ',') return;
                      else
                      {
                          bool result;
                          if (c == '!')
                          {
                              result = !(stack.Pop() == 't');
                          }
                          else
                          {
                              var operationStack = new Stack<bool>();
                              while (stack.Count > 0 && stack.Peek() != ')')
                              {
                                  operationStack.Push(stack.Pop() == 't');
                              }
                              result = c == '&' ? operationStack.All(b => b) : operationStack.Any(b => b);
                          }
                          stack.Pop(); // Remove ')'
                          stack.Push(result ? 't' : 'f');
                      }
                  });

        return stack.Pop() == 't';
    }
    #endregion

    public override bool Execute(string input)
    {
        return ParseBoolExprLINQ(input);
    }

    public override IEnumerable<string> TestCases()
    {
        return new List<string>()
        {
            "!(&(f,t))",
            "&(|(f))",
            "|(f,f,f,t)",
            "|(&(t,f,t),t)"
        };
    }
}
