using System;
using System.Threading;
public interface ISingleton
{
	int getData();
	void setData(int d);
}
public class Singleton:ISingleton
 {
    private static Singleton instance;
	public int data=5;
	private static readonly object mylock = new object();
    private Singleton() { }

       public static Singleton calling()
        {
			   lock(mylock)
			 {
         		try
				{
                if (instance == null)
                    instance = new Singleton();
                
            	}
				catch(OutOfMemoryException ex)
	    	   {
			     Console.WriteLine("Exception "+ex);
		       }
				   return instance;
		    }
		   
        }
	public int getData()
	{
		return data;
	}
	public void setData(int d)
	{
		data=d;
	}
	
	
    
}

public class MainClass
{

		public static void Main()
	{
			ISingleton IObj1=null,IObj2=null;
			int data=0;
			//IObj1=Singleton.calling();
			Thread t1=new Thread(()=>{ IObj1=Singleton.calling();});
			t1.Start();
			Thread.Sleep(2000);
			if(IObj1!=null)
			{
		    data=IObj1.getData();
			Console.WriteLine(data);
		
			IObj1.setData(8);
			data=IObj1.getData();
			Console.WriteLine(data);
			}
			
			Thread t2=new Thread(()=>{ IObj2=Singleton.calling();});
			t2.Start();
			Thread.Sleep(2000);
			
			if(IObj2!=null)	
			{
			
		
		    data=IObj2.getData();
			Console.WriteLine(data);
		
			IObj2.setData(9);
			data=IObj2.getData();
			Console.WriteLine(data);
			}
		
	}
}


