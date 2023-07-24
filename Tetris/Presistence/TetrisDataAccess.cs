using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Presistence
{
    public class TetrisDataAccess : ITetrisDataAccess
    {
        public async Task<TetrisMap> LoadAsync(string path)
        {
            try
            {
                using(StreamReader reader = new StreamReader(path))
                {
                    String line = await reader.ReadLineAsync() ?? String.Empty;
                    String[] numbers = line.Split(' ');
                    int rows = Int32.Parse(numbers[0]);
                    int columns = Int32.Parse(numbers[1]);

                    TetrisMap table = null!;
                    if (columns == 4)
                    {
                        table = new TetrisMap(Model.GameDifficulty.Easy);
                    }

                    if (columns == 8)
                    {
                        table = new TetrisMap(Model.GameDifficulty.Medium);
                    }

                    if (columns == 12)
                    {
                        table = new TetrisMap(Model.GameDifficulty.Hard);
                    }

                    for (int i = 0; i < rows; i++)
                    {
                        line = await reader.ReadLineAsync() ?? String.Empty;
                        numbers = line.Split(' ');

                        for (int j = 0; j < columns; j++) {

                            table.SetValue(i, j, Int32.Parse(numbers[j]));
                        }
                    }

                    return table;
                }
            }
            catch
            {
                throw new TetrisDataEcxeption();
            }
        }

        public async Task SaveAsync(string path, TetrisMap table)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(path))
                {
                    writer.Write(table.Rows);
                    await writer.WriteLineAsync(" " + table.Columns);

                    for (int i = 0; i < table.Rows; i++)
                    {
                        for (int j = 0; j < table.Columns; j++)
                        {
                            await writer.WriteAsync(table.GetValue(i, j) + " ");
                        }
                        await writer.WriteLineAsync();
                    }
                }
            }
            catch
            {
                throw new TetrisDataEcxeption();
            }
        }
    }
}
