using TLDLoader;
using Random = UnityEngine.Random;

namespace StickySnek
{
    public class StickySnek : Mod
    {
        public override string ID
        {
            get { return "StickySnek"; }
        }

        public override string Name
        {
            get { return "STICKY SNEK"; }
        }

        public override string Author
        {
            get { return "LukasMojzis"; }
        }

        public override bool LoadInDB
        {
            get { return true; }
        }

        public override string Version
        {
            get { return "1.0.0"; }
        }

        public override void dbLoad()
        {
            
            if (!itemdatabase.d.ggold.GetComponent<GoldbarScript>())
                itemdatabase.d.ggold.AddComponent<GoldbarScript>();
            
            if (!itemdatabase.d.gleszivocso.GetComponent<SiphonScript>())
                itemdatabase.d.gleszivocso.AddComponent<SiphonScript>();
            
            if (!itemdatabase.d.ghand01.GetComponent<LimbScript>())
                itemdatabase.d.ghand01.AddComponent<LimbScript>();
            
            if (!itemdatabase.d.cnyul.GetComponent<BunnyScript>())
                itemdatabase.d.cnyul.AddComponent<BunnyScript>();
            
        }
    }
}