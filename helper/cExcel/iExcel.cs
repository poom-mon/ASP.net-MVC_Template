using System.Data;
using System.IO;

namespace cExcel
{
    interface iExcel
    {
        DataTable readToDT(string path);
        DataTable readToDT(Stream file);
    }
}
