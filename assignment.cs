using System;
public class Singleton
 {
    private static Singleton instance;
	public int data=5;
	private static readonly object mylock = new object();
    private Singleton() { }

       public static Singleton Instance
        {
	      get
            {
			   lock(mylock)
			 {
       
                if (instance == null)
                    instance = new Singleton();
                return instance;
            }
	       }
        }
	
		public static void Main()
	{
		var inst=Singleton.Instance;
			inst.data=6;
			
		var inst2=Singleton.Instance;	
			inst.data=8;
			
			int ans=inst.data;
			int ans1=inst.data;
			
		Console.WriteLine("First Call"+ans);
		Console.WriteLine("Second Call"+ans1);
	}
    
}


