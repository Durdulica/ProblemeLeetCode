using probleme;
internal class Program
{
    private static void Main()
    {
        var siruri = new ProblemeSiruri();
        var vectori = new ProblemeVectori();

        int[] v = { 1, 1, 2 };
        
        for (int i = 0; i < vectori.Ex7(v); i++) {
            Console.Write(v[i] + " ");
        }
    }
}
