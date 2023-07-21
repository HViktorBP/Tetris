using Moq;
using Tetris.Model;
using Tetris.Presistence;

namespace TetrisTest
{
    [TestClass]
    public class TetrisTest
    {
        private TetrisGameModel _model = null!; // a tesztelendő modell
        private TetrisMap _mockedTable = null!; // mockolt játéktábla
        private Mock<ITetrisDataAccess> _mock = null!; // az adatelérés mock-ja

        [TestInitialize]
        public void Initialize()
        {
            _mockedTable = new TetrisMap(GameDifficulty.Medium);
            _mockedTable.SetValue(5, 4, 1);
            _mockedTable.SetValue(6, 4, 1);
            _mockedTable.SetValue(7, 4, 1);
            _mockedTable.SetValue(8, 4, 1);

            _mock = new Mock<ITetrisDataAccess>();
            _mock.Setup(mock => mock.LoadAsync(It.IsAny<String>()))
                .Returns(() => Task.FromResult(_mockedTable));

            _model = new TetrisGameModel(GameDifficulty.Medium, _mock.Object);
        }
        [TestMethod]
        public void TetrisGameModelNewGameMediumTest()
        {
            _model.NewGame();

            Assert.AreEqual(GameDifficulty.Medium, _model.diff);

            Int32 emptyFields = 0;
            for (Int32 i = 0; i < _model.status.mapY; i++)
                for (Int32 j = 0; j < _model.status.mapX; j++)
                    if (_model.status.map[i, j] == 0)
                        emptyFields++;

            Assert.AreEqual(128, emptyFields);
        }

        [TestMethod]
        public void TetrisGameModelNewGameEasyTest()
        {
            _model.diff = GameDifficulty.Easy;
            _model.NewGame();

            Assert.AreEqual(GameDifficulty.Easy, _model.diff);

            Int32 emptyFields = 0;
            for (Int32 i = 0; i < _model.status.mapY; i++)
                for (Int32 j = 0; j < _model.status.mapX; j++)
                    if (_model.status.map[i, j] == 0)
                        emptyFields++;

            Assert.AreEqual(64, emptyFields);
        }

        [TestMethod]
        public void TetrisGameModelNewGameHardTest()
        {
            _model.diff = GameDifficulty.Hard;
            _model.NewGame();

            Assert.AreEqual(GameDifficulty.Hard, _model.diff);

            Int32 emptyFields = 0;
            for (Int32 i = 0; i < _model.status.mapY; i++)
                for (Int32 j = 0; j < _model.status.mapX; j++)
                    if (_model.status.map[i, j] == 0)
                        emptyFields++;

            Assert.AreEqual(192, emptyFields);
        }

        [TestMethod]
        public async Task TetrisGameModelLoadTest()
        {
            _model.NewGame();

            await _model.LoadGameAsync(String.Empty);

            for (Int32 i = 0; i < _model.status.mapY; i++)
                for (Int32 j = 0; j < _model.status.mapX; j++)
                {
                    Assert.AreEqual(_mockedTable.map[i, j], _model.status.map[i, j]);
                }

            _mock.Verify(dataAccess => dataAccess.LoadAsync(String.Empty), Times.Once());
        }
    }
}