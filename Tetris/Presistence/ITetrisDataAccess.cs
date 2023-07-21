using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Presistence
{
    public interface ITetrisDataAccess
    {
        Task<TetrisMap> LoadAsync(String path);

        Task SaveAsync(String path, TetrisMap table);
    }
}
