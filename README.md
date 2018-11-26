# algorithm0

using System;

namespace Vincent.Algorithm;
{
  public class MNPlatform
  {
    public int GetAvailablePath(int m, int n)
    {
        if(m < 1 || n < 1)
        {
          return 0;
        }
        
        if(m == 1)
        {
          return n + 1;
        }

        if(n == 1)
        {
          return m + 1;
        }

        return GetAvailablePath(m - 1, n) + GetAvailablePath(m, n - 1);
    }

  }

}
