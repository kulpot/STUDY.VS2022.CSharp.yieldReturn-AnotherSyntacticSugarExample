using System;
using System.Collections;

//ref link:https://www.youtube.com/watch?v=Dxzo0mRCp0Q&list=PL9B5E4C37F7B234A8&index=4
//

class MainClass
{
    class NumbersHybrid : IEnumerable<int>, IEnumerator<int>
    {
        int state;
        int current;
        public bool MoveNext()
        {
            switch (state)
            {
                case 0:
                    Console.WriteLine("Begin");
                    Console.WriteLine("yielding 3");
                    //yield return 3;
                    current = 3;
                    state = 1;
                    break;
                case 1:
                    Console.WriteLine("yielding 5");
                    //yield return 5;
                    current = 5;
                    state = 2;
                    break;
                case 2:
                    Console.WriteLine("yielding 1");
                    //yield return 1;
                    current = 1;
                    state = 3;
                    break;
                case 3:
                    Console.WriteLine("end!!!");
                    return false;
            }   
            return true;
        }

        public int Current
        {
            get { return current; }
        }
        
        object IEnumerator.Current
        {
            get { return Current; }
        }
        public void Reset()
        {
            throw new NotImplementedException();
        }
        public void Dispose() { }
        public IEnumerator<int> GetEnumerator()
        {
            return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    static IEnumerable<int> Numbers
    {
        get
        {
            /*Console.WriteLine("Begin");
            Console.WriteLine("yielding 3");
            yield return 3;
            Console.WriteLine("yielding 5");
            yield return 5;
            Console.WriteLine("yielding 1");
            yield return 1;
            Console.WriteLine("end!!!");*/
            return new NumbersHybrid();
        }
    }
    static void Main()
    {
        IEnumerable<int> source = Numbers;
        IEnumerator<int> rator = source.GetEnumerator();
        while(rator.MoveNext())
            Console.WriteLine(rator.Current);

        //IEnumerable<int> source = Numbers; // output: none
        //foreach (int i in Numbers)       
        //    Console.WriteLine(i);    
    }
}