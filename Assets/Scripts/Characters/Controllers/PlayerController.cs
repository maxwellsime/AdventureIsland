using Characters.Services;
using Characters.Views;

namespace Characters.Controllers
{
    public class PlayerController
    {
        private PlayerService _playerService;
        private StatsView _statsView;

        public PlayerController()
        {
            _playerService = new PlayerService();
            //_statsView = StatsView();

            //_statsView.InitializeView();
        }
        
        // Change Stat
        // _playerService.ChangeStat
        // _statsView.RefreshPlayerStat(Stat, int)
    }
}