using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace UpdateTool
{
    // This implementation defines a very simple comparison
    // between two FileInfo objects. It only compares the name
    // of the files being compared and their length in bytes.
    class FileCompare : System.Collections.Generic.IEqualityComparer<System.IO.FileInfo>
    {
        public FileCompare()
        {
        }

        public bool Equals(System.IO.FileInfo f1, System.IO.FileInfo f2)
        {
            bool bRet = true;

            do
            {
                bRet = (f1.Name == f2.Name && f1.Length == f2.Length);
                if (!bRet) break;

                byte[] byHashCode1 = ComputeHash(f1.FullName);
                byte[] byHashCode2 = ComputeHash(f2.FullName);

                bRet = byHashCode1.SequenceEqual(byHashCode2);

            } while (false);

            return bRet;
        }

        // Return a hash that reflects the comparison criteria. According to the
        // rules for IEqualityComparer<T>, if Equals is true, then the hash codes must
        // also be equal. Because equality as defined here is a simple value equality, not
        // reference identity, it is possible that two or more objects will produce the same
        // hash code.  
        public int GetHashCode(System.IO.FileInfo fi)
        {
            //string s = $"{fi.Name}{fi.Length}";
            string s = string.Format("{0}{1}", fi.Name, fi.Length);
            return s.GetHashCode();
        }

        private byte[] ComputeHash(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(File.ReadAllBytes(filePath));
            }
        }
    }  
}
