using System.Collections.Generic;

namespace DomainModel
{
    public class TileFactory
    {
        private static readonly Dictionary<string, ITile> _tiles = new Dictionary<string, ITile>();

        public static ITile GetTile(string tileType)
        {            
            switch(tileType)
            {
                case "Ceramic" :
                    if(!_tiles.ContainsKey("Ceramic"))
                        _tiles["Ceramic"] = new CeramicTile();
                    return _tiles["Ceramic"];                                        
                case "Stone" :
                    if (!_tiles.ContainsKey("Stone"))
                        _tiles["Stone"] = new StoneTile();
                    return _tiles["Stone"];                    
                default:
                    break;
            }
            return null;
        }
    }
}
