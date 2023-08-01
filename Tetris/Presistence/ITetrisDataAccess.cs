using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Presistence
{
    /// <summary>
    /// The interface class, which I will use for working with game's data(Saving and loading). 
    /// </summary>
    public interface ITetrisDataAccess
    {
        Task<TetrisMap> LoadAsync(String path);

        Task SaveAsync(String path, TetrisMap table);
    }
}
