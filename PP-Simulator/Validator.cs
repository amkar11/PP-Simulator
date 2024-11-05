public class Validator{
    public static int Limiter(int value, int min, int max) { 
        if (value < min) { return min; }
        else if (value > max) { return max; }
        else return value;
    }

    public static string Shortener(string? value, int min, int max, char placeholder) { 
        if (value == null){
            return string.Empty;
        }   
        value = value.Trim();
        if (value.Length < min)
        {
            while (value.Length < min) { value += $"{placeholder}"; }
        }
        if (value.Length > max)
        {
            value = value.Substring(0, max);
            value = value.Trim();
            if (value.Length < min)
            {
                while (value.Length != min) { value += $"{placeholder}"; }
            }
        }
        value = char.ToUpper(value[0]) + value.Substring(1);
        return value;
    }
}