class LegacyAPI{
    [Obsolete("OldFeature is not in use anymore.Please use NewFeature().")]
    public void OldFeature(){
        Console.WriteLine("Executing old Feature.");
    }
    public void NewFeature(){
        Console.WriteLine("Executing new Feature.");
    }
    static void Main(){
        LegacyAPI a=new LegacyAPI();
        a.OldFeature();
        a.NewFeature();
    }
}