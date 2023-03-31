using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace Mod
{
  public class Mod : MonoBehaviour
  {

      public static void Main()
        {

      CategoryBuilder.Create("One Piece pack", "Things about one piece", ModAPI.LoadSprite("category.png"));
      ModAPI.RegisterLiquid("GOHEAL", new GoHeal());

//https://www.youtube.com/watch?v=bno8OdmAWxM

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Brick"),
   NameOverride = "Empty Throne",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Empty Throne.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Empty Thronethumb.png"),
   AfterSpawn = (Instance) =>
   {

     Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/Empty Throne.png", 1f);
     Instance.FixColliders();

                        }
                    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Brick"),
        NameOverride = "gear4fist",
        NameToOrderByOverride = "ZZZZZZZZZZZZZZ",
        CategoryOverride = ModAPI.FindCategory("Null"),
        ThumbnailOverride = ModAPI.LoadSprite("Darkness.png"),
        AfterSpawn = (Instance) =>
        {

            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/gear4fist.png");

            foreach (var c in Instance.GetComponents<Collider2D>())
            {
                GameObject.Destroy(c);
            }
            Instance.FixColliders();
            Instance.gameObject.AddComponent<ryuohaoshokuluffy>();
            Instance.gameObject.AddComponent<eqp>();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/gear4fist.png");
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Brick"),
        NameOverride = "gear5fist",
        NameToOrderByOverride = "ZZZZZZZZZZZZZZ",
        CategoryOverride = ModAPI.FindCategory("Null"),
        ThumbnailOverride = ModAPI.LoadSprite("Darkness.png"),
        AfterSpawn = (Instance) =>
        {
          var childObject11 = new GameObject();
          childObject11.transform.SetParent(Instance.transform);
          childObject11.transform.localPosition = new Vector3(0, 0f);
          childObject11.transform.localScale = new Vector3(1f, 1f);
          var childSprite11 = childObject11.AddComponent<SpriteRenderer>();
          childSprite11.color = new Color(1f, 0.3f, 0f, 0.090f);
          childSprite11.sprite = ModAPI.LoadSprite("image/gear5fist2.png");
          childSprite11.sharedMaterial = ModAPI.FindMaterial("VeryBright");
          childSprite11.sortingLayerName = "Middle";

            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/gear5fist.png");

            foreach (var c in Instance.GetComponents<Collider2D>())
            {
                GameObject.Destroy(c);
            }
            Instance.FixColliders();
            Instance.gameObject.GetComponent<PhysicalBehaviour>().Temperature = 100000f;
            Instance.gameObject.AddComponent<ryuohaoshokuluffy>();
            Instance.gameObject.AddComponent<eqp>();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/gear5fist.png");
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Brick"),
        NameOverride = "King Kong Gun",
        NameToOrderByOverride = "ZZZZZZZZZZZZZZ",
        CategoryOverride = ModAPI.FindCategory("Null"),
        ThumbnailOverride = ModAPI.LoadSprite("Darkness.png"),
        AfterSpawn = (Instance) =>
        {

          Instance.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;
          Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/King Kong Gun.png");
            foreach (var c in Instance.GetComponents<Collider2D>())
            {
                GameObject.Destroy(c);
            }
            Instance.FixColliders();
            Instance.gameObject.AddComponent<ryuohaoshokuluffy>();
            Instance.gameObject.AddComponent<eqp>();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/King Kong Gun.png");
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Brick"),
        NameOverride = "Bajrangun",
        NameToOrderByOverride = "ZZZZZZZZZZZZZZ",
        CategoryOverride = ModAPI.FindCategory("Null"),
        ThumbnailOverride = ModAPI.LoadSprite("Darkness.png"),
        AfterSpawn = (Instance) =>
        {

          Instance.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;
          Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/Bajrangunx4.png");
            foreach (var c in Instance.GetComponents<Collider2D>())
            {
                GameObject.Destroy(c);
            }
            Instance.FixColliders();
            Instance.GetComponent<PhysicalBehaviour>().Charge = 10f;
            Instance.gameObject.GetComponent<PhysicalBehaviour>().Temperature = 100000f;
            Instance.gameObject.AddComponent<ryuohaoshokuluffy>();
            Instance.gameObject.AddComponent<eqp>();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/Bajrangunx4.png");
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Brick"),
        NameOverride = "Donutfist",
        NameToOrderByOverride = "ZZZZZZZZZZZZZZ",
        CategoryOverride = ModAPI.FindCategory("Null"),
        ThumbnailOverride = ModAPI.LoadSprite("Darkness.png"),
        AfterSpawn = (Instance) =>
        {

            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/Donutfist.png");

            foreach (var c in Instance.GetComponents<Collider2D>())
            {
                GameObject.Destroy(c);
            }

            Instance.FixColliders();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/Donutfist.png");
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Brick"),
        NameOverride = "kamusari",
        NameToOrderByOverride = "ZZZZZZZZZZZZZZ",
        CategoryOverride = ModAPI.FindCategory("Null"),
        ThumbnailOverride = ModAPI.LoadSprite("Darkness.png"),
        AfterSpawn = (Instance) =>
        {

            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/kamusari.png",1f);

            foreach (var c in Instance.GetComponents<Collider2D>())
            {
                GameObject.Destroy(c);
            }
            var glow = ModAPI.CreateLight(Instance.transform, Color.red, 5, 1);
            glow.Brightness = 1;
            Instance.gameObject.AddComponent<ryuohaoshokuluffy>();
            Instance.gameObject.AddComponent<Haoshoku>();
            Instance.FixColliders();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/kamusari.png",1f);
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Brick"),
        NameOverride = "gear2fist",
        NameToOrderByOverride = "ZZZZZZZZZZZZZZ",
        CategoryOverride = ModAPI.FindCategory("Null"),
        ThumbnailOverride = ModAPI.LoadSprite("Darkness.png"),
        AfterSpawn = (Instance) =>
        {

            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/gear2fist.png");

            foreach (var c in Instance.GetComponents<Collider2D>())
            {
                GameObject.Destroy(c);
            }

            var trailrenderer = Instance.gameObject.AddComponent<TrailRenderer>();
            trailrenderer.startWidth = 0.15f;
            trailrenderer.endWidth = 0.15f;
            trailrenderer.time = 0.3f;
            trailrenderer.startColor = new Color32(255, 255, 255, 255);
            trailrenderer.endColor = new Color32(255, 255, 255, 255);
            Material mat = new Material(ModAPI.FindMaterial("Sprites-Default"));
            mat.SetTexture("_MainTex", ModAPI.LoadTexture("image/gear2fist.png"));
            trailrenderer.material = mat;
            trailrenderer.sortingOrder = Instance.GetComponent<SpriteRenderer>().sortingOrder = 1;



            Instance.FixColliders();
            Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
            Instance.gameObject.AddComponent<ryuohaoshokuluffy>();
            Instance.gameObject.AddComponent<eqp>();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/gear2fist.png");
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Brick"),
        NameOverride = "hanafist",
        NameToOrderByOverride = "ZZZZZZZZZZZZZZ",
        CategoryOverride = ModAPI.FindCategory("Null"),
        ThumbnailOverride = ModAPI.LoadSprite("Darkness.png"),
        AfterSpawn = (Instance) =>
        {

            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/hanafist.png");

            foreach (var c in Instance.GetComponents<Collider2D>())
            {
                GameObject.Destroy(c);
            }
            Instance.FixColliders();
            Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/hanafist.png");
        }
    }
);

ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Rod"),
  NameOverride = "Flame-Flame Fruit",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = "The Mera Mera no Mi is a Logia-type Devil Fruit that allows the user to create, control, and transform into fire at will.",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/MeraMeranoMithumb.png"),
  AfterSpawn = (Instance) =>
  {
    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/MeraMeranoMi.png", 2f);
    Instance.GetComponent<PhysicalBehaviour>().InitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soft");
    Instance.AddComponent<MeraMeranoMi>();
    Instance.FixColliders();
  }
}
);

ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Rod"),
  NameOverride = "Sand-Sand Fruit",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = "The Suna Suna no Mi is a Logia-type Devil Fruit that allows the user to create, control, and transform into sand at will, turning the user into a Sand Human.",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/SunaSunanoMithumb.png"),
  AfterSpawn = (Instance) =>
  {
    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/SunaSunanoMi.png",2f);
    Instance.GetComponent<PhysicalBehaviour>().InitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soft");
    Instance.AddComponent<SunaSunanoMi>();
    Instance.FixColliders();
  }
}
);

ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Rod"),
  NameOverride = "Ice-Ice Fruit",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = "The Hie Hie no Mi is a Logia-type Devil Fruit that allows the user to create, control, and transform into ice at will, turning them into a Freezing Human.",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/HieHienoMithumb.png"),
  AfterSpawn = (Instance) =>
  {
    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/HieHienoMi.png", 2f);
    Instance.GetComponent<PhysicalBehaviour>().InitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soft");
    Instance.AddComponent<HieHienoMi>();
    Instance.FixColliders();
  }
}
);

ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Rod"),
  NameOverride = "Magma-Magma Fruit",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = "The Magu Magu no Mi is a Logia-type Devil Fruit that allows the user to create, control, and transform into magma at will, turning the user into a Magma Human.",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/MaguMagunoMithumb.png"),
  AfterSpawn = (Instance) =>
  {
    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/MaguMagunoMi.png", 2f);
    Instance.GetComponent<PhysicalBehaviour>().InitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soft");
    Instance.AddComponent<MaguMagunoMi>();
    Instance.FixColliders();
  }
}
);

ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Rod"),
  NameOverride = "Rumble-Rumble Fruit",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = "The Goro Goro no Mi is a Logia-type Devil Fruit, that grants the power to create, control, and transform into lightning at will, making its user a Lightning Human.",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/GoroGoronoMithumb.png"),
  AfterSpawn = (Instance) =>
  {
    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/GoroGoronoMi.png", 2f);
    Instance.GetComponent<PhysicalBehaviour>().InitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soft");
    Instance.AddComponent<GoroGoronoMi>();
    Instance.FixColliders();
  }
}
);

ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Rod"),
  NameOverride = "Glint-Glint Fruit",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = "The Pika Pika no Mi is a Logia-type Devil Fruit that allows the user to create, control, and transform into light at will, turning the user into a Light Human.",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/PikaPikanoMithumb.png"),
  AfterSpawn = (Instance) =>
  {
    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/PikaPikanoMi.png", 3f);
    Instance.GetComponent<PhysicalBehaviour>().InitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soft");
    Instance.AddComponent<PikaPikanoMi>();
    Instance.FixColliders();
  }
}
);

ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Rod"),
  NameOverride = "Dark-Dark Fruit",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = "The y Yami no Mi is a Special Logia-type Devil Fruit that allows the user to create and control darkness at will, making the user a Darkness Human.",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/YamiYaminoMithumb.png"),
  AfterSpawn = (Instance) =>
  {
    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/YamiYaminoMi.png",2f);
    Instance.GetComponent<PhysicalBehaviour>().InitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soft");
    Instance.AddComponent<YamiYaminoMi>();
    Instance.FixColliders();
  }
}
);


ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Rod"),
  NameOverride = "Tremor-Tremor Fruit",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = "The Gura Gura no Mi is a Paramecia-type Devil Fruit which allows the user to create vibrations, or quakes, making the user a Tremor Human.",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/GuraGuranoMithumb.png"),
  AfterSpawn = (Instance) =>
  {
    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/GuraGuranoMi.png", 3f);
    Instance.GetComponent<PhysicalBehaviour>().InitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soft");
    Instance.AddComponent<GuraGuranoMi>();
    Instance.FixColliders();
  }
}
);

ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Rod"),
  NameOverride = "String-String Fruit",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = "The Ito Ito no Mi is a Paramecia-type Devil Fruit that allows the user to create and manipulate strings, making the user a String Human.",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/ItoItonoMithumb.png"),
  AfterSpawn = (Instance) =>
  {
    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/ItoItonoMi.png", 3f);
    Instance.GetComponent<PhysicalBehaviour>().InitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soft");
    Instance.AddComponent<ItoItonoMi>();
    Instance.FixColliders();
  }
}
);

ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Rod"),
  NameOverride = "Venom-Venom Fruit",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = "The Doku Doku no Mi is a Paramecia-type Devil Fruit  that grants the user the ability to produce and control different types of poison, as well as grants immunity to all forms of poison, making the user a Poison Human.",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/DokuDokunoMithumb.png"),
  AfterSpawn = (Instance) =>
  {
    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/DokuDokunoMi.png", 2f);
    Instance.GetComponent<PhysicalBehaviour>().InitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soft");
    Instance.AddComponent<DokuDokunoMi>();
    Instance.FixColliders();
  }
}
);

ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Rod"),
  NameOverride = "Gum-Gum Fruit",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = "The Gomu Gomu no Mi is a Paramecia-type Devil Fruit that gives the user's body the properties of rubber, making the user a Rubber Human.",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/GomuGomunoMithumb.png"),
  AfterSpawn = (Instance) =>
  {
    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/GomuGomunoMi.png", 2f);
    Instance.GetComponent<PhysicalBehaviour>().InitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soft");
    Instance.AddComponent<GomuGomunoMi>();
    Instance.FixColliders();
  }
}
);

ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Rod"),
  NameOverride = "Bomb-Bomb Fruit",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = "The Bomu Bomu no Mi is a Paramecia-type Devil Fruit that allows the user to make any part of their body explode, whether it be their limbs, hair, mucus, or even breath, making the user a Bomb Human.",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/BomuBomunoMithumb.png"),
  AfterSpawn = (Instance) =>
  {
    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/BomuBomunoMi.png", 3f);
    Instance.GetComponent<PhysicalBehaviour>().InitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soft");
    Instance.AddComponent<BomuBomunoMi>();
    Instance.FixColliders();
  }
}
);

ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Rod"),
  NameOverride = "Op-Op Fruit",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = "The Ope Ope no Mi is a Paramecia-type Devil Fruit, making the user a Free Modification Human.",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/OpeOpenoMithumb.png"),
  AfterSpawn = (Instance) =>
  {
    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/OpeOpenoMi.png",3f);
    Instance.GetComponent<PhysicalBehaviour>().InitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soft");
    Instance.AddComponent<OpeOpenoMi>();
    Instance.FixColliders();
  }
}
);

ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Rod"),
  NameOverride = "Magnet-Magnet Fruit",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = "The Jiki Jiki no Mi is a Paramecia-type Devil Fruit which allows the user to create magnetic forces and use them to control metal.",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/JikiJikinoMithumb.png"),
  AfterSpawn = (Instance) =>
  {
    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/JikiJikinoMi.png",1.5f);
    Instance.GetComponent<PhysicalBehaviour>().InitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soft");
    Instance.AddComponent<JikiJikinoMi>();
    Instance.FixColliders();
  }
}
);

ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Rod"),
  NameOverride = "Slip-Slip Fruit",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = "The Sube Sube no Mi is a Paramecia-type Devil Fruit that makes the user's body smooth and slippery, which in turn makes most attacks and all objects slide off their body.",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/SubeSubenMithumb.png"),
  AfterSpawn = (Instance) =>
  {
    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/SubeSubenMi.png",2f);
    Instance.GetComponent<PhysicalBehaviour>().InitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soft");
    Instance.AddComponent<SubeSubenMi>();
    Instance.FixColliders();
  }
}
);

ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Rod"),
  NameOverride = "Revive-Revive Fruit",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = "The Yomi Yomi no Mi is a Paramecia-type Devil Fruit, to use several other soul-based abilities, making the user a Reviving Human.",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/YomiYominoMithumb.png"),
  AfterSpawn = (Instance) =>
  {
    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/YomiYominoMi.png",2f);
    Instance.GetComponent<PhysicalBehaviour>().InitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soft");
    Instance.AddComponent<YomiYominoMi>();
    Instance.FixColliders();
  }
}
);

ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Rod"),
  NameOverride = "Dough-Dough Fruit",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = "The Mochi Mochi no Mi is a Special Paramecia-type Devil Fruit that allows the user to create, control, and transform into mochi.",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/MochiMochinoMithumb.png"),
  AfterSpawn = (Instance) =>
  {
    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/MochiMochinoMi.png",2f);
    Instance.GetComponent<PhysicalBehaviour>().InitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soft");
    Instance.AddComponent<MochiMochinoMi>();
    Instance.FixColliders();
  }
}
);

ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Rod"),
  NameOverride = "Flower-Flower Fruit",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = "The Hana Hana no Mi is a Paramecia-type Devil Fruit that allows the user to replicate and sprout pieces of their body from the surface of any object or living thing.",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/HanaHananoMithumb.png"),
  AfterSpawn = (Instance) =>
  {
    Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/HanaHananoMi.png",2f);
    Instance.GetComponent<PhysicalBehaviour>().InitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = .01f;
    Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soft");
    Instance.AddComponent<HanaHananoMi>();
    Instance.FixColliders();
  }
}
);

      ModAPI.Register(
          new Modification()
              {
         OriginalItem = ModAPI.FindSpawnable("Human"),
         NameOverride = "Normal marine",
         NameToOrderByOverride = "Z1",
         DescriptionOverride = "Normal marine,He is a new navy and likes cabbage and Sauerkraut.",
         CategoryOverride = ModAPI.FindCategory("One Piece pack"),
         ThumbnailOverride = ModAPI.LoadSprite("image/Normal marinethumbnail.png"),
         AfterSpawn = (Instance) =>
         {

         var skin = ModAPI.LoadTexture("image/Normal marine.png");
         var flesh = ModAPI.LoadTexture("Flesh.png");
         var bone = ModAPI.LoadTexture("Bone.png");
         var head = Instance.transform.Find("Head");
         var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
         var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
         var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
         var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
         var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
         var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
         var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
         var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
         var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
         var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
         var upper = Instance.transform.Find("Body").Find("UpperBody");
         var middle = Instance.transform.Find("Body").Find("MiddleBody");
         var Lower = Instance.transform.Find("Body").Find("LowerBody");


         upper.transform.localScale = new Vector3(1.2f, 1.2f);
         middle.transform.localScale = new Vector3(1.1f, 1.2f);
         head.transform.localScale = new Vector3(0.7f, 0.7f);
         arm3.transform.localScale = new Vector3(1.18f, 1.2f);
         arm4.transform.localScale = new Vector3(1.18f, 1.2f);
         arm1.transform.localScale = new Vector3(1.18f, 1.2f);
         arm2.transform.localScale = new Vector3(1.18f, 1.2f);
         leg3.transform.localScale = new Vector3(1.19f, 1.2f);
         leg4.transform.localScale = new Vector3(1.19f, 1.2f);
         leg1.transform.localScale = new Vector3(1.19f, 1.2f);
         leg2.transform.localScale = new Vector3(1.19f, 1.2f);
         foot1.transform.localScale = new Vector3(1.19f, 1.2f);
         foot2.transform.localScale = new Vector3(1.19f, 1.2f);

         head.transform.localPosition = new Vector3(0.01f, 0.700f);
         arm3.transform.localPosition = new Vector3(0f, -0.15f);
         arm4.transform.localPosition = new Vector3(0f, -0.15f);
         arm1.transform.localPosition = new Vector3(0f, -0.60f);
         arm2.transform.localPosition = new Vector3(0f, -0.60f);
         leg3.transform.localPosition = new Vector3(0f, -0.46f);
         leg4.transform.localPosition = new Vector3(0f, -0.46f);
         leg1.transform.localPosition = new Vector3(0f, -0.96f);
         leg2.transform.localPosition = new Vector3(0f, -0.96f);
         foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
         foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);


         var person = Instance.GetComponent<PersonBehaviour>();
         person.SetBodyTextures(skin, flesh, bone, 1);
         foreach (var body in person.Limbs)
          {
              body.BaseStrength *= 1f;
              body.Health *= 20f;
              body.BreakingThreshold *= 1f;
              body.transform.root.localScale *= 1f;

          //Marinehat
            var ca = new GameObject("Marinehat");
            ca.transform.SetParent(Instance.transform.Find("Head"));
            ca.transform.localPosition = new Vector3(0, 0f);
            ca.transform.localScale = new Vector3(1f, 1f);
            var caSprite = ca.AddComponent<SpriteRenderer>();
            caSprite.sprite = ModAPI.LoadSprite("image/Marinehat.png");
            ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
            ca.AddComponent<UseEventTrigger>().Action = () => {
            caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                              };

                              }
                          }
                      }
      );



      ModAPI.Register(
          new Modification()
              {
         OriginalItem = ModAPI.FindSpawnable("Human"),
         NameOverride = "Normal pirate",
         NameToOrderByOverride = "Z1",
         DescriptionOverride = "Normal pirate,He likes steaks with dripping blood.",
         CategoryOverride = ModAPI.FindCategory("One Piece pack"),
         ThumbnailOverride = ModAPI.LoadSprite("image/Normal piratethumbnail.png"),
         AfterSpawn = (Instance) =>
         {

         var skin = ModAPI.LoadTexture("image/Normal pirate.png");
         var flesh = ModAPI.LoadTexture("Flesh.png");
         var bone = ModAPI.LoadTexture("Bone.png");
         var head = Instance.transform.Find("Head");
         var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
         var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
         var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
         var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
         var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
         var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
         var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
         var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
         var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
         var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
         var upper = Instance.transform.Find("Body").Find("UpperBody");
         var middle = Instance.transform.Find("Body").Find("MiddleBody");
         var Lower = Instance.transform.Find("Body").Find("LowerBody");


         upper.transform.localScale = new Vector3(1.2f, 1.2f);
         middle.transform.localScale = new Vector3(1.1f, 1.2f);
         head.transform.localScale = new Vector3(0.7f, 0.7f);
         arm3.transform.localScale = new Vector3(1.18f, 1.2f);
         arm4.transform.localScale = new Vector3(1.18f, 1.2f);
         arm1.transform.localScale = new Vector3(1.18f, 1.2f);
         arm2.transform.localScale = new Vector3(1.18f, 1.2f);
         leg3.transform.localScale = new Vector3(1.19f, 1.2f);
         leg4.transform.localScale = new Vector3(1.19f, 1.2f);
         leg1.transform.localScale = new Vector3(1.19f, 1.2f);
         leg2.transform.localScale = new Vector3(1.19f, 1.2f);
         foot1.transform.localScale = new Vector3(1.19f, 1.2f);
         foot2.transform.localScale = new Vector3(1.19f, 1.2f);

         head.transform.localPosition = new Vector3(0.01f, 0.700f);
         arm3.transform.localPosition = new Vector3(0f, -0.15f);
         arm4.transform.localPosition = new Vector3(0f, -0.15f);
         arm1.transform.localPosition = new Vector3(0f, -0.60f);
         arm2.transform.localPosition = new Vector3(0f, -0.60f);
         leg3.transform.localPosition = new Vector3(0f, -0.46f);
         leg4.transform.localPosition = new Vector3(0f, -0.46f);
         leg1.transform.localPosition = new Vector3(0f, -0.96f);
         leg2.transform.localPosition = new Vector3(0f, -0.96f);
         foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
         foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);


         var person = Instance.GetComponent<PersonBehaviour>();
         person.SetBodyTextures(skin, flesh, bone, 1);
         foreach (var body in person.Limbs)
          {
              body.BaseStrength *= 1f;
              body.Health *= 20f;
              body.BreakingThreshold *= 1f;
              body.transform.root.localScale *= 1f;

          //
            var ca = new GameObject("Edward Newgate old1");
            ca.transform.SetParent(Instance.transform.Find("Head"));
            ca.transform.localPosition = new Vector3(0, 0f);
            ca.transform.localScale = new Vector3(1f, 1f);
            var caSprite = ca.AddComponent<SpriteRenderer>();
            caSprite.sprite = ModAPI.LoadSprite("image/Edward Newgate old1.png");
            ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
            ca.AddComponent<UseEventTrigger>().Action = () => {
            caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                              };

                              }
                          }
                      }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Monkey D. Luffy 2 years ago",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Monkey D. Luffy 2 years ago.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Monkey D. Luffy 2 years agothumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Monkey D. Luffy 2 years ago.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");
   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");


   upper.transform.localScale = new Vector3(1.2f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);

       var allColliders = Instance.GetComponentsInChildren<Collider2D>();
       foreach (var a in allColliders)
           foreach (var b in allColliders)
               Physics2D.IgnoreCollision(a, b);

   var person = Instance.GetComponent<PersonBehaviour>();
   person.BoneBreakClips = new AudioClip[] { ModAPI.LoadSound("Sound/Lbone.mp3") };
   person.Limbs[0].gameObject.AddComponent<LuffyVoice>();
   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 1f;
        body.Health *= 100f;
        body.BreakingThreshold *= 1f;
        body.transform.root.localScale *= 1f;


    //
      var ca = new GameObject("Monkey D. Luffy 2 years agohat");
      ca.transform.SetParent(Instance.transform.Find("Head"));
      ca.transform.localPosition = new Vector3(0, 0f);
      ca.transform.localScale = new Vector3(1f, 1f);
      var caSprite = ca.AddComponent<SpriteRenderer>();
      caSprite.sprite = ModAPI.LoadSprite("image/Monkey D. Luffy 2 years agohat.png");
      ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ca.AddComponent<UseEventTrigger>().Action = () => {
      caSprite.sprite = ModAPI.LoadSprite("none.png");
      };


     var ornamentobject = new GameObject("Luffyhair2.png");
     ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
     ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
     ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
     ornamentobject.transform.localScale = new Vector3(1f, 1f);
     var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
     ornamentsprite.sprite = ModAPI.LoadSprite("image/Luffyhair2.png",2f);
     ornamentsprite.sortingLayerName = "Middle";

     var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
     var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


     ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
     ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

                        }



                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Monkey D. Luffy Ryuo ver",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = ""+"\n <color=white>This form can be used Ryuo, and Haoshoku Haki can be Infusion into the body,This provides tremendous power.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Monkey D. Luffy Ryuo verthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Monkey D. Luffy Ryuo ver.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.2f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   head.gameObject.AddComponent<hao>();
   Lower.gameObject.AddComponent<kenbun>();
   arm1.gameObject.AddComponent<ryuohaoshokuluffy>();
   arm2.gameObject.AddComponent<ryuohaoshokuluffy>();
   arm1.gameObject.AddComponent<ppower>();
   arm2.gameObject.AddComponent<ppower>();

   var trailrenderer = arm1.gameObject.AddComponent<TrailRenderer>();
   trailrenderer.startWidth = 0.5f;
   trailrenderer.endWidth = 0.5f;
   trailrenderer.time = 0.2f;
   trailrenderer.startColor = new Color32(255, 255, 255, 255);
   trailrenderer.endColor = new Color32(255, 255, 255, 255);
   Material mat = new Material(ModAPI.FindMaterial("Sprites-Default"));
   mat.SetTexture("_MainTex", ModAPI.LoadTexture("image/haoshock.png"));
   trailrenderer.material = mat;
   trailrenderer.sortingOrder = arm1.GetComponent<SpriteRenderer>().sortingOrder = 1;
   trailrenderer.enabled = false;

   arm1.gameObject.AddComponent<UseEventTrigger>().Action = () =>
       {
           trailrenderer.enabled = !trailrenderer.enabled;
       };

   var trailrenderer2 = arm2.gameObject.AddComponent<TrailRenderer>();
   trailrenderer2.startWidth = 0.5f;
   trailrenderer2.endWidth = 0.5f;
   trailrenderer2.time = 0.2f;
   trailrenderer2.startColor = new Color32(255, 255, 255, 255);
   trailrenderer2.endColor = new Color32(255, 255, 255, 255);
   Material mat2 = new Material(ModAPI.FindMaterial("Sprites-Default"));
   mat2.SetTexture("_MainTex", ModAPI.LoadTexture("image/haoshock.png"));
   trailrenderer2.material = mat2;
   trailrenderer2.sortingOrder = arm2.GetComponent<SpriteRenderer>().sortingOrder = 1;
   trailrenderer2.enabled = false;

   arm2.gameObject.AddComponent<UseEventTrigger>().Action = () =>
       {
           trailrenderer2.enabled = !trailrenderer2.enabled;
       };

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.2f;
        body.Health *= 1000f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1f;
        body.PhysicalBehaviour.BurningProgressionMultiplier = -1000000;
        body.gameObject.AddComponent<strongrege>();

        UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger0.Event = new UnityEvent();
        useEventTrigger0.Event.AddListener(delegate ()
         {
           ModAPI.CreateParticleEffect("Vapor", head.transform.position);
          Audio2.Play();
        });

        UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });

        UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger2.Event = new UnityEvent();
        useEventTrigger2.Event.AddListener(delegate ()
         {
           Audio3.Play();
        });


         var backpack = new GameObject("hat and cape");
         backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
         backpack.transform.localPosition = new Vector3(0, 0f);
         backpack.transform.localScale = new Vector3(1f, 1f);
         var backpackSprite = backpack.AddComponent<SpriteRenderer>();
         backpackSprite.sprite = ModAPI.LoadSprite("image/hat and cape.png");
         backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
         backpack.AddComponent<UseEventTrigger>().Action = () => {
         backpackSprite.sprite = ModAPI.LoadSprite("none.png");
        };

        var ornamentobject = new GameObject("Luffyhair.png");
        ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
        ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
        ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        ornamentobject.transform.localScale = new Vector3(1f, 1f);
        var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
        ornamentsprite.sprite = ModAPI.LoadSprite("image/Luffyhair.png",2f);
        ornamentsprite.sortingLayerName = "Middle";

                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Luffy Gear Second",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = ""+"\n <color=white>Gear Second is a technique that enhances the user's strength, speed, and mobility.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Luffy gear 2thumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Luffy gear 2.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.2f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");


   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   head.gameObject.AddComponent<hao>();
   arm1.gameObject.AddComponent<ryuohaoshokuluffy>();
   arm2.gameObject.AddComponent<ryuohaoshokuluffy>();

   var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


   ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
   ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

   arm1.gameObject.AddComponent<UseEventTrigger>().Action = () =>
   {
       GameObject Projectile = GameObject.Instantiate(ModAPI.FindSpawnable("gear2fist").Prefab);
       CatalogBehaviour.PerformMod(ModAPI.FindSpawnable("gear2fist"), Projectile);
       Projectile.transform.rotation = arm1.transform.rotation;
       Projectile.transform.eulerAngles += new Vector3(0, 0, -90);
       Projectile.gameObject.GetComponent<PhysicalBehaviour>().SpawnSpawnParticles = false;
       Projectile.transform.position = arm1.transform.position + (-arm1.transform.up * 2.1f);
       Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(Projectile.transform.right * 1000);
       Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(-Projectile.transform.right * -1000);
       var col = Projectile.AddComponent<NoCollide>();
       col.NoCollideSetA = Projectile.GetComponents<Collider2D>();
       col.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();
       Destroy(Projectile, 0.200f);
   };

   arm2.gameObject.AddComponent<UseEventTrigger>().Action = () =>
   {
       GameObject Projectile = GameObject.Instantiate(ModAPI.FindSpawnable("gear2fist").Prefab);
       CatalogBehaviour.PerformMod(ModAPI.FindSpawnable("gear2fist"), Projectile);
       Projectile.transform.rotation = arm2.transform.rotation;
       Projectile.transform.eulerAngles += new Vector3(0, 0, -90);
       Projectile.gameObject.GetComponent<PhysicalBehaviour>().SpawnSpawnParticles = false;
       Projectile.transform.position = arm2.transform.position + (-arm2.transform.up * 2.1f);
       Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(Projectile.transform.right * 1000);
       Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(-Projectile.transform.right * -1000);
       var col = Projectile.AddComponent<NoCollide>();
       col.NoCollideSetA = Projectile.GetComponents<Collider2D>();
       col.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();
       Destroy(Projectile, 0.200f);
   };

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.2f;
        body.Health *= 1000f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1f;
        body.PhysicalBehaviour.BurningProgressionMultiplier = -1000000;
        body.gameObject.AddComponent<strongrege>();

        UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger0.Event = new UnityEvent();
        useEventTrigger0.Event.AddListener(delegate ()
         {
           ModAPI.CreateParticleEffect("Vapor", head.transform.position);
          Audio2.Play();
        });

        UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });


         var backpack = new GameObject("hat and cape");
         backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
         backpack.transform.localPosition = new Vector3(0, 0f);
         backpack.transform.localScale = new Vector3(1f, 1f);
         var backpackSprite = backpack.AddComponent<SpriteRenderer>();
         backpackSprite.sprite = ModAPI.LoadSprite("image/hat and cape.png");
         backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
         backpack.AddComponent<UseEventTrigger>().Action = () => {
         backpackSprite.sprite = ModAPI.LoadSprite("none.png");
        };

        var backpack2 = new GameObject("Luffy gear 2steam");
        backpack2.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
        backpack2.transform.localPosition = new Vector3(0, 0f);
        backpack2.transform.localScale = new Vector3(1f, 1f);
        var backpack2Sprite = backpack2.AddComponent<SpriteRenderer>();
        backpack2Sprite.sprite = ModAPI.LoadSprite("image/Luffy gear 2steam.png");
        backpack2.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        backpack2.AddComponent<UseEventTrigger>().Action = () => {
        backpack2Sprite.sprite = ModAPI.LoadSprite("none.png");
       };


        var ornamentobject = new GameObject("Luffyhair.png");
        ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
        ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
        ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        ornamentobject.transform.localScale = new Vector3(1f, 1f);
        var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
        ornamentsprite.sprite = ModAPI.LoadSprite("image/Luffyhair.png",2f);
        ornamentsprite.sortingLayerName = "Middle";

                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Nightmare Luffy",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = ""+"\n <color=white>Before his fight against Gecko Moria and Oars during the Thriller Bark Arc, the Rolling Pirates helped Luffy become temporarily stronger by infusing him with the power of one hundred shadows that were separated from their owners by Moria's use of the Kage Kage no Mi.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Nightmare Luffythumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Nightmare Luffy.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var leg1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(2.6f, 1.4f);
   middle.transform.localScale = new Vector3(2.3f, 1.4f);
   Lower.transform.localScale = new Vector3(2f, 1.2f);

   arm3.transform.localScale = new Vector3(1.8f, 1.62f);
   arm4.transform.localScale = new Vector3(1.8f, 1.62f);
   arm1.transform.localScale = new Vector3(2.4f, 1.62f);
   arm2.transform.localScale = new Vector3(2.4f, 1.62f);
   leg3.transform.localScale = new Vector3(1.2f, 1f);
   leg4.transform.localScale = new Vector3(1.2f, 1f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);


   head.transform.localPosition = new Vector3(0f, 0.736f);
   arm3.transform.localPosition = new Vector3(0f, -0.19f);
   arm4.transform.localPosition = new Vector3(0f, -0.19f);
   arm1.transform.localPosition = new Vector3(0f, -0.77f);
   arm2.transform.localPosition = new Vector3(0f, -0.77f);

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   head.gameObject.AddComponent<hao>();

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 1f;
        body.Health *= 1000f;
        body.BreakingThreshold *= 100f;
        body.transform.root.localScale *= 1.09f;
        body.IsAndroid = true;
        body.gameObject.AddComponent<strongrege>();
        UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger0.Event = new UnityEvent();
        useEventTrigger0.Event.AddListener(delegate ()
         {
           ModAPI.CreateParticleEffect("Vapor", head.transform.position);
          Audio2.Play();
        });

         var backpack = new GameObject("Nightmare Luffy sword");
         backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
         backpack.transform.localPosition = new Vector3(0, 0f);
         backpack.transform.localScale = new Vector3(0.7f, 1f);
         var backpackSprite = backpack.AddComponent<SpriteRenderer>();
         backpackSprite.sprite = ModAPI.LoadSprite("image/Nightmare Luffy sword.png",2f);
         backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
         backpack.AddComponent<UseEventTrigger>().Action = () => {
         backpackSprite.sprite = ModAPI.LoadSprite("none.png");
        };

        var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
        var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


        ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";


         var ornamentobject = new GameObject("Boundmanhair.png");
         ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
         ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
         ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
         ornamentobject.transform.localScale = new Vector3(1f, 1f);
         var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
         ornamentsprite.sprite = ModAPI.LoadSprite("image/Boundmanhair.png",2f);
         ornamentsprite.sortingLayerName = "Middle";



                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Luffy Gear Fourth Boundman",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = ""+"\n <color=white>One of the techniques of luffy, this greatly increased the elasticity, tension, and hardness of rubber,This form was created in order to combat the many powerful and large animals on Rusukaina.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Luffy gear 4 Boundmanthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Luffy gear 4 Boundman.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var leg1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(2.6f, 1.3f);
   middle.transform.localScale = new Vector3(2.6f, 1.3f);
   Lower.transform.localScale = new Vector3(2.6f, 1.2f);

   arm3.transform.localScale = new Vector3(2.4f, 1.62f);
   arm4.transform.localScale = new Vector3(2.4f, 1.62f);
   arm1.transform.localScale = new Vector3(2.4f, 1.62f);
   arm2.transform.localScale = new Vector3(2.4f, 1.62f);
   leg3.transform.localScale = new Vector3(1.2f, 1f);
   leg4.transform.localScale = new Vector3(1.2f, 1f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);


   head.transform.localPosition = new Vector3(0f, 0.73f);
   arm3.transform.localPosition = new Vector3(0f, -0.203f);
   arm4.transform.localPosition = new Vector3(0f, -0.203f);
   arm1.transform.localPosition = new Vector3(0f, -0.78f);
   arm2.transform.localPosition = new Vector3(0f, -0.78f);

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 100;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/g5sound.mp3");

   AudioClip Repulsor = ModAPI.LoadSound("sssa.mp3");
   AudioClip beam2 = ModAPI.LoadSound("sssa.mp3");


   head.gameObject.AddComponent<hao>();
   arm1.gameObject.AddComponent<ryuohaoshokuluffy>();
   arm2.gameObject.AddComponent<ryuohaoshokuluffy>();

   foreach (var Limbs in person.Limbs)
   {;
       if (Limbs.GetComponent<GripBehaviour>())
       {
           Limbs.gameObject.AddComponent<UseEventTrigger>().Action = () =>
           {
               AudioSource audio = Limbs.gameObject.AddComponent<AudioSource>();
               audio.spatialBlend = 1;
               audio.PlayOneShot(Repulsor);
           };
       }
   }

   arm1.gameObject.AddComponent<UseEventTrigger>().Action = () =>
   {
       GameObject Projectile = GameObject.Instantiate(ModAPI.FindSpawnable("gear4fist").Prefab);
       CatalogBehaviour.PerformMod(ModAPI.FindSpawnable("gear4fist"), Projectile);
       Projectile.transform.rotation = arm1.transform.rotation;
       Projectile.transform.eulerAngles += new Vector3(0, 0, -90);
       Projectile.gameObject.GetComponent<PhysicalBehaviour>().SpawnSpawnParticles = false;
       Projectile.transform.position = arm1.transform.position + (-arm1.transform.up * 3.3f);
       Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(Projectile.transform.right * 4000);
       Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(-Projectile.transform.right * -4000);
       var col = Projectile.AddComponent<NoCollide>();
       col.NoCollideSetA = Projectile.GetComponents<Collider2D>();
       col.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();
       Destroy(Projectile, 0.300f);
   };

   arm2.gameObject.AddComponent<UseEventTrigger>().Action = () =>
   {
     GameObject Projectile = GameObject.Instantiate(ModAPI.FindSpawnable("gear4fist").Prefab);
     CatalogBehaviour.PerformMod(ModAPI.FindSpawnable("gear4fist"), Projectile);
     Projectile.transform.rotation = arm2.transform.rotation;
     Projectile.transform.eulerAngles += new Vector3(0, 0, -90);
     Projectile.gameObject.GetComponent<PhysicalBehaviour>().SpawnSpawnParticles = false;
     Projectile.transform.position = arm2.transform.position + (-arm2.transform.up * 3.3f);
     Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(Projectile.transform.right * 4000);
     Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(-Projectile.transform.right * -4000);
     var col = Projectile.AddComponent<NoCollide>();
     col.NoCollideSetA = Projectile.GetComponents<Collider2D>();
     col.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();
     Destroy(Projectile, 0.300f);
   };

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.5f;
        body.Health *= 100000f;
        body.BreakingThreshold *= 100f;
        body.transform.root.localScale *= 1.04f;
        body.IsAndroid = true;
        var allColliders = Instance.GetComponentsInChildren<Collider2D>();
        foreach (var a in allColliders)
            foreach (var b in allColliders)
                Physics2D.IgnoreCollision(a, b);

        body.gameObject.AddComponent<strongrege>();
        UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger0.Event = new UnityEvent();
        useEventTrigger0.Event.AddListener(delegate ()
         {
           ModAPI.CreateParticleEffect("Vapor", head.transform.position);
          Audio2.Play();
        });
        body.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Metal");
        body.GetComponent<PhysicalBehaviour>().OverrideImpactSounds = new AudioClip[]
      {
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
        };

         var backpack = new GameObject("Boundmansteam");
         backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
         backpack.transform.localPosition = new Vector3(0, 0f);
         backpack.transform.localScale = new Vector3(0.7f, 1f);
         var backpackSprite = backpack.AddComponent<SpriteRenderer>();
         backpackSprite.sprite = ModAPI.LoadSprite("image/Boundmansteam.png");
         backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
         backpack.AddComponent<UseEventTrigger>().Action = () => {
         backpackSprite.sprite = ModAPI.LoadSprite("none.png");
        };

        var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
        var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


        ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";


         var ornamentobject = new GameObject("Boundmanhair.png");
         ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
         ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
         ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
         ornamentobject.transform.localScale = new Vector3(1f, 1f);
         var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
         ornamentsprite.sprite = ModAPI.LoadSprite("image/Boundmanhair.png",2f);
         ornamentsprite.sortingLayerName = "Middle";



          }

          arm2.gameObject.GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("ena", "Enable King Kong Gun", "Enable King Kong Gun", new UnityAction[1]
          {
              (UnityAction) (() =>
              {
                GameObject Projectile2 = GameObject.Instantiate(ModAPI.FindSpawnable("King Kong Gun").Prefab);
                CatalogBehaviour.PerformMod(ModAPI.FindSpawnable("King Kong Gun"), Projectile2);
                Projectile2.transform.SetParent(arm2.gameObject.transform);
                Projectile2.transform.position = arm2.transform.position;
                Projectile2.transform.localPosition = new Vector3(0f, -1.2f);
                Projectile2.transform.eulerAngles = arm2.transform.eulerAngles;
                Audio3.Play();
                Projectile2.gameObject.GetComponent<PhysicalBehaviour>().SpawnSpawnParticles = false;
                Projectile2.gameObject.AddComponent<FixedJoint2D>();
                Projectile2.gameObject.GetComponent<FixedJoint2D>().connectedBody = arm2.gameObject.GetComponent<Rigidbody2D>();
                var col = Projectile2.AddComponent<NoCollide>();
                col.NoCollideSetA = Projectile2.GetComponents<Collider2D>();
                col.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

          arm2.gameObject.GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("disa", "Disable King Kong Gun", "Disable King Kong Gun", new UnityAction[1]
          {
              (UnityAction) (() =>
              {
                Destroy(Projectile2);
              })
          }));

          })
      }));

                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Luffy Gear Fourth Tankman",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = ""+"\n <color=white>A muscle balloon is formed in the abdomen. Unlike Boundman, Busoshoku Haki is a technique that focuses on the abdomen and is easier to defend than physical attack.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Luffy gear 4 Tankmanthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Luffy gear 4 Tankman.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var leg1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(14f, 6.3f);
   middle.transform.localScale = new Vector3(14f, 6.3f);
   Lower.transform.localScale = new Vector3(14f, 6.2f);

   arm3.transform.localScale = new Vector3(3.4f, 2.62f);
   arm4.transform.localScale = new Vector3(3.4f, 2.62f);
   arm1.transform.localScale = new Vector3(3.4f, 2.62f);
   arm2.transform.localScale = new Vector3(3.4f, 2.62f);
   leg3.transform.localScale = new Vector3(1.2f, 1f);
   leg4.transform.localScale = new Vector3(1.2f, 1f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);


   head.transform.localPosition = new Vector3(0f, 4.440f);
   upper.transform.localPosition = new Vector3(0f, 3.5f);
   middle.transform.localPosition = new Vector3(0f, 2.2f);
   Lower.transform.localPosition = new Vector3(0f, 0.75f);
   arm3.transform.localPosition = new Vector3(0f, 3.17f);
   arm4.transform.localPosition = new Vector3(0f, 3.17f);
   arm1.transform.localPosition = new Vector3(0f, 2.2f);
   arm2.transform.localPosition = new Vector3(0f, 2.2f);

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   head.gameObject.AddComponent<hao>();
   arm1.gameObject.AddComponent<ryuohaoshokuluffy>();
   arm2.gameObject.AddComponent<ryuohaoshokuluffy>();


   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.4f;
        body.IsAndroid = true;
        body.Health *= 1000f;
        body.BreakingThreshold *= 100f;
        body.transform.root.localScale *= 1.03f;
        body.gameObject.AddComponent<strongrege>();
        UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger0.Event = new UnityEvent();
        useEventTrigger0.Event.AddListener(delegate ()
         {
           ModAPI.CreateParticleEffect("Vapor", head.transform.position);
          Audio2.Play();
        });
        body.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Metal");
        body.GetComponent<PhysicalBehaviour>().OverrideImpactSounds = new AudioClip[]
      {
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
        };

         var backpack = new GameObject("Tankman steam");
         backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
         backpack.transform.localPosition = new Vector3(0, 0f);
         backpack.transform.localScale = new Vector3(0.7f, 1f);
         var backpackSprite = backpack.AddComponent<SpriteRenderer>();
         backpackSprite.sprite = ModAPI.LoadSprite("image/Tankman steam.png",2f);
         backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
         backpack.AddComponent<UseEventTrigger>().Action = () => {
         backpackSprite.sprite = ModAPI.LoadSprite("none.png");
        };

        var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
        var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


        ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";


         var ornamentobject = new GameObject("Boundmanhair.png");
         ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
         ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
         ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
         ornamentobject.transform.localScale = new Vector3(1f, 1f);
         var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
         ornamentsprite.sprite = ModAPI.LoadSprite("image/Boundmanhair.png",2f);
         ornamentsprite.sortingLayerName = "Middle";



                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Luffy Gear Fourth Snakeman",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = ""+"\n <color=white>One of the techniques of luffy, this greatly increased the elasticity, tension, and hardness of rubber,The physical ability increases exponentially,and it is a speed-optimized form.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Luffy gear 4 snakemanthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Luffy gear 4 snakeman.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var leg1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.6f, 1.3f);
   middle.transform.localScale = new Vector3(1.5f, 1.3f);
   Lower.transform.localScale = new Vector3(1.4f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.5f, 1.3f);
   arm4.transform.localScale = new Vector3(1.5f, 1.3f);
   arm1.transform.localScale = new Vector3(1.5f, 1.3f);
   arm2.transform.localScale = new Vector3(1.5f, 1.3f);
   leg3.transform.localScale = new Vector3(1.2f, 1f);
   leg4.transform.localScale = new Vector3(1.2f, 1f);


   head.transform.localPosition = new Vector3(0.01f, 0.723f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.63f);
   arm2.transform.localPosition = new Vector3(0f, -0.63f);

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   AudioClip Repulsor = ModAPI.LoadSound("sssa.mp3");
   AudioClip beam2 = ModAPI.LoadSound("sssa.mp3");

   head.gameObject.AddComponent<hao>();
   arm1.gameObject.AddComponent<ryuohaoshokuluffy>();
   arm2.gameObject.AddComponent<ryuohaoshokuluffy>();

   arm1.gameObject.AddComponent<python1>();
   arm2.gameObject.AddComponent<python1>();

   foreach (var Limbs in person.Limbs)
   {;

       if (Limbs.GetComponent<GripBehaviour>())
       {
           Limbs.gameObject.AddComponent<UseEventTrigger>().Action = () =>
           {


               AudioSource audio = Limbs.gameObject.AddComponent<AudioSource>();
               audio.spatialBlend = 1;
               audio.PlayOneShot(Repulsor);
           };
       }
   }



   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.3f;
        body.Health *= 1000f;
        body.BreakingThreshold *= 100f;
        body.transform.root.localScale *= 1.04f;
        body.IsAndroid = true;
        body.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Metal");
        body.gameObject.AddComponent<strongrege>();
        UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger0.Event = new UnityEvent();
        useEventTrigger0.Event.AddListener(delegate ()
         {
           ModAPI.CreateParticleEffect("Vapor", head.transform.position);
          Audio2.Play();
        });
        body.GetComponent<PhysicalBehaviour>().OverrideImpactSounds = new AudioClip[]
      {
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                    ModAPI.LoadSound("Sound/gear 4 sound.mp3"),
                                  };


        //snakeman steam
         var backpack = new GameObject("snakeman steam");
         backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
         backpack.transform.localPosition = new Vector3(0, 0f);
         backpack.transform.localScale = new Vector3(0.9f, 1f);
         var backpackSprite = backpack.AddComponent<SpriteRenderer>();
         backpackSprite.sprite = ModAPI.LoadSprite("image/snakeman steam.png");
         backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
         backpack.AddComponent<UseEventTrigger>().Action = () => {
         backpackSprite.sprite = ModAPI.LoadSprite("none.png");
        };

        var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
        var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


        ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";



         var ornamentobject = new GameObject("Snakemanhair.png");
         ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
         ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
         ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
         ornamentobject.transform.localScale = new Vector3(1f, 1f);
         var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
         ornamentsprite.sprite = ModAPI.LoadSprite("image/Snakemanhair.png",1.5f);
         ornamentsprite.sortingLayerName = "Middle";


                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Luffy Gear Fifth",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = ""+"\n <color=white>Gear 5 is a transformation technique created as a result of Luffy awakening the power of the Gomu Gomu no Mi.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Luffy gear 5thumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Luffy gear 5.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.2f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

    AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

  
   head.gameObject.AddComponent<hao>();
   arm1.gameObject.AddComponent<ryuohaoshokuluffy>();
   arm2.gameObject.AddComponent<ryuohaoshokuluffy>();
   Lower.gameObject.AddComponent<kenbun>();

   AudioClip Repulsor = ModAPI.LoadSound("Sound/g5sound.mp3");
   AudioClip beam2 = ModAPI.LoadSound("Sound/g5sound.mp3");

   var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


   ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";
   ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";

   foreach (var Limbs in person.Limbs)
   {;

       if (Limbs.GetComponent<GripBehaviour>())
       {
           Limbs.gameObject.AddComponent<UseEventTrigger>().Action = () =>
           {


               AudioSource audio = Limbs.gameObject.AddComponent<AudioSource>();
               audio.spatialBlend = 1;
               audio.PlayOneShot(Repulsor);
           };
       }
   }

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.5f;
        body.Health *= 100f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        var allColliders = Instance.GetComponentsInChildren<Collider2D>();
        foreach (var a in allColliders)
        foreach (var b in allColliders)
        Physics2D.IgnoreCollision(a, b);
        body.transform.root.localScale *= 1f;
        body.gameObject.AddComponent<regenstuffnthing>();             
                            if (body.GetComponent<GripBehaviour>())
                            {
                                //      SuperPowerSetups.SetSlidingHandWeapon(body, person, Instance.gameObject, ModAPI.LoadSprite("People/Mr Fantastic/Hammer.png"), "Hammer", true,true);
                            }
                            Sprite WeaponSprite = ModAPI.LoadSprite("image/Bajrangunx4.png");

                            string OriginalItem = "Hammer";
                            bool RedoCollisions = true;
                            bool SmoothScale = true; ;
                            if (!body.GetComponent<SlideableHandWeapon>())
                            {
                                if (body.GetComponent<GripBehaviour>())
                                {
                                    GameObject NewClaw = GameObject.Instantiate(ModAPI.FindSpawnable(OriginalItem).Prefab);
                                    NewClaw.transform.SetParent(body.transform);
                                    NewClaw.GetComponent<PhysicalBehaviour>().DisplayBloodDecals = false;
                                    NewClaw.gameObject.AddComponent<ryuohaoshokuluffy>();
                                    if (Instance.transform.localScale.x < 0)
                                        NewClaw.transform.localScale *= 10f;
                                    NewClaw.GetComponent<SpriteRenderer>().sprite = WeaponSprite;//get the SpriteRenderer and replace its sprite with a custom one
                                    if (RedoCollisions)
                                    {
                                        NewClaw.FixColliders();
                                    }
                                    NewClaw.transform.position = body.transform.position;

                                    NewClaw.transform.eulerAngles = new Vector3(NewClaw.transform.eulerAngles.x, NewClaw.transform.eulerAngles.y, NewClaw.transform.eulerAngles.z + 180);
                                    foreach (var limbs in person.Limbs)
                                        Physics2D.IgnoreCollision(limbs.GetComponent<Collider2D>(), NewClaw.GetComponent<Collider2D>());
                                    foreach (var limbs in person.Limbs)
                                    {
                                        if (limbs.GetComponent<SlideableHandWeapon>())
                                            Physics2D.IgnoreCollision(limbs.GetComponent<SlideableHandWeapon>().Claw.GetComponent<Collider2D>(), NewClaw.GetComponent<Collider2D>());
                                    }
                                    body.gameObject.AddComponent<FixedJoint2D>().connectedBody = NewClaw.GetComponent<Rigidbody2D>();
                                    body.gameObject.AddComponent<SlideableHandWeapon>().SetUpClaw(body.gameObject, NewClaw);
                                    body.gameObject.GetComponent<SlideableHandWeapon>().OgGripPos = body.gameObject.GetComponent<GripBehaviour>().GripPosition;
                                    body.gameObject.GetComponent<SlideableHandWeapon>().Scale = SmoothScale;
                                    body.gameObject.GetComponent<GripBehaviour>().GripPosition = Vector3.one * 1000;
                                    body.gameObject.AddComponent<UseEventTrigger>().Action = () =>
                                    {
                                        body.gameObject.GetComponent<SlideableHandWeapon>().ToggleClaw();
                                    };
                                }
                            }

        UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger0.Event = new UnityEvent();
        useEventTrigger0.Event.AddListener(delegate ()
         {
           ModAPI.CreateParticleEffect("Vapor", head.transform.position);
          Audio2.Play();
        });

        UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });

UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger2.Event = new UnityEvent();
        useEventTrigger2.Event.AddListener(delegate ()
         {
           Audio3.Play();
        });


        var backpack2 = new GameObject("gear5 steam");
        backpack2.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
        backpack2.transform.localPosition = new Vector3(0, 0f);
        backpack2.transform.localScale = new Vector3(1f, 1f);
        var backpack2Sprite = backpack2.AddComponent<SpriteRenderer>();
        backpack2Sprite.sprite = ModAPI.LoadSprite("image/gear5 steam.png");
        backpack2.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        backpack2.GetComponent<SpriteRenderer>().sortingOrder = 2;
        backpack2.AddComponent<UseEventTrigger>().Action = () => {
        backpack2Sprite.sprite = ModAPI.LoadSprite("none.png");
       };
                                  
 var ca = new GameObject("gear5hair");
       ca.transform.SetParent(Instance.transform.Find("Head"));
       ca.transform.localPosition = new Vector3(0, 0f);
       ca.transform.localScale = new Vector3(1f, 1f);
       var caSprite = ca.AddComponent<SpriteRenderer>();
       caSprite.sprite = ModAPI.LoadSprite("image/gear5hair.png",4f);
       ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
       ca.GetComponent<SpriteRenderer>().sortingOrder = 1;
       ca.AddComponent<UseEventTrigger>().Action = () => {
       caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                         };


        }
           
                  }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Roronoa Zoro Haoshoku ver",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = ""+"\n <color=white>This form can be used Ryuo, and Haoshoku Haki can be Infusion into the body,This provides tremendous power.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Roronoa Zoro Haoshoku verthumbnial.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Roronoa Zoro Haoshoku ver.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.2f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");
   


   head.gameObject.AddComponent<hao>();
   Lower.gameObject.AddComponent<kenbun>();
   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();
   leg1.gameObject.AddComponent<Busoshoku>();
   leg2.gameObject.AddComponent<Busoshoku>();

   var Awwzoro = Instance.transform.Find("Head").gameObject;
   Awwzoro.name = "Head"; //this is so it works with the armor mod :)

   var Awwzoro2 = Awwzoro.AddComponent<GripBehaviour>();
   Awwzoro2.GripPosition = new Vector3(0.30f, -0.01f, 0.45f);
   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.2f;
        body.Health *= 1000f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1f;
        body.PhysicalBehaviour.BurningProgressionMultiplier = -1000000;
        body.gameObject.AddComponent<strongrege>();

        UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger0.Event = new UnityEvent();
        useEventTrigger0.Event.AddListener(delegate ()
         {
           ModAPI.CreateParticleEffect("Vapor", head.transform.position);
          Audio2.Play();
        });
        UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });

        UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger2.Event = new UnityEvent();
        useEventTrigger2.Event.AddListener(delegate ()
         {
           Audio3.Play();
        });

        var ca = new GameObject("zorohat");
        ca.transform.SetParent(Instance.transform.Find("Head"));
        ca.transform.localPosition = new Vector3(0, 0f);
        ca.transform.localScale = new Vector3(1f, 1f);
        var caSprite = ca.AddComponent<SpriteRenderer>();
        caSprite.sprite = ModAPI.LoadSprite("image/zorohat.png");
        ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        ca.AddComponent<UseEventTrigger>().Action = () => {
        caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                           };

        //zoroSwords
         var backpack = new GameObject("zoroSwords");
         backpack.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
         backpack.transform.localPosition = new Vector3(0, 0f);
         backpack.transform.localScale = new Vector3(1f, 1f);
         var backpackSprite = backpack.AddComponent<SpriteRenderer>();
         backpackSprite.sprite = ModAPI.LoadSprite("image/zoroSwords.png");
         backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
         backpack.AddComponent<UseEventTrigger>().Action = () => {
         backpackSprite.sprite = ModAPI.LoadSprite("none.png");

        };

        var ca3 = new GameObject("Roronoa Zoro Haoshoku vercape.png");
        ca3.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
        ca3.transform.localPosition = new Vector3(0, 0f);
        ca3.transform.localScale = new Vector3(1f, 1f);
        var ca3Sprite = ca3.AddComponent<SpriteRenderer>();
        ca3Sprite.sprite = ModAPI.LoadSprite("image/Roronoa Zoro Haoshoku vercape.png");
        ca3.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        ca3.AddComponent<UseEventTrigger>().Action = () => {
        ca3Sprite.sprite = ModAPI.LoadSprite("none.png");
        };

        var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
        var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


        ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

      person.SetBodyTextures(skin, flesh, bone, 1);
      person.SetBruiseColor(000, 000, 000);
      person.SetSecondBruiseColor(000, 000, 0000);
      person.SetThirdBruiseColor(000, 000, 000);
      person.SetBloodColour(000, 000, 000);
      person.SetRottenColour(000, 000, 000);


                        }
                    }
                }
);



ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Nami",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Cat Burglar, Nami is the navigator of the Straw Hat Pirates. She is the third member of the crew and the second to join, doing so during the Orange Town Arc.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/namithumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Nami.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");
   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");


   arm3.transform.localScale = new Vector3(1.10f, 1.2f);
   arm4.transform.localScale = new Vector3(1.10f, 1.2f);
   arm1.transform.localScale = new Vector3(1.10f, 1.2f);
   arm2.transform.localScale = new Vector3(1.10f, 1.2f);
   leg3.transform.localScale = new Vector3(1.12f, 1.2f);
   leg4.transform.localScale = new Vector3(1.12f, 1.2f);
   leg1.transform.localScale = new Vector3(1.12f, 1.2f);
   leg2.transform.localScale = new Vector3(1.12f, 1.2f);
   foot1.transform.localScale = new Vector3(1.12f, 1.2f);
   foot2.transform.localScale = new Vector3(1.12f, 1.2f);

   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.01f, 0.67f);

   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.064f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.064f, -1.2513f);



   var person = Instance.GetComponent<PersonBehaviour>();
   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 1f;
        body.Health *= 1000f;
        body.BreakingThreshold *= 1f;
        body.transform.root.localScale *= 1f;

        var bodyuper = Instance.transform.Find("Body").Find("UpperBody");
        bodyuper.localPosition = new Vector3(0.0f, 0.4f);

        Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/namibreast.png");
        Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().material.SetTexture("_FleshTex", ModAPI.LoadTexture("image/Fleshbreast.png"));
        Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().material.SetTexture("_BoneTex", ModAPI.LoadTexture("image/Bonebreast.png"));

        var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
        var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


        ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";
        ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";

      var ca = new GameObject("namihair");
      ca.transform.SetParent(Instance.transform.Find("Head"));
      ca.transform.localPosition = new Vector3(0, 0f);
      ca.transform.localScale = new Vector3(1f, 1f);
      var caSprite = ca.AddComponent<SpriteRenderer>();
      caSprite.sprite = ModAPI.LoadSprite("image/namihair.png",2.5f);
      ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ca.AddComponent<UseEventTrigger>().Action = () => {
      caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                        };

                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Usopp",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "God Usopp is the sniper of the Straw Hat Pirates. He is the fourth member of the crew and the third to join.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Usoppthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Usopp.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");
   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.2f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);

   var person = Instance.GetComponent<PersonBehaviour>();
   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 1f;
        body.Health *= 100f;
        body.BreakingThreshold *= 1f;
        body.transform.root.localScale *= 1f;


    //Usopp item
    var ca = new GameObject("Usopp item.png");
    ca.transform.SetParent(Instance.transform.Find("Head"));
    ca.transform.localPosition = new Vector3(0, 0f);
    ca.transform.localScale = new Vector3(1f, 1f);
    var caSprite = ca.AddComponent<SpriteRenderer>();
    caSprite.sprite = ModAPI.LoadSprite("image/Usopp item.png");
    ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
    ca.AddComponent<UseEventTrigger>().Action = () => {
    caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                      };

                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Sanji",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Black Leg Sanji born as Vinsmoke Sanji is the cook of the Straw Hat Pirates. He is the fifth member of the crew and the fourth to join, doing so at the end of the Baratie Arc.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Sanjithumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Sanji.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");
   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.2f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   Lower.gameObject.AddComponent<kenbun>();
   foot1.gameObject.AddComponent<Firebeh>();
   foot2.gameObject.AddComponent<Firebeh>();
   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();
   leg1.gameObject.AddComponent<Busoshoku>();
   leg2.gameObject.AddComponent<Busoshoku>();

   var person = Instance.GetComponent<PersonBehaviour>();
   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.1f;
        body.Health *= 100f;
        body.BreakingThreshold *= 1f;
        body.transform.root.localScale *= 1f;
        body.IsAndroid = true;
        body.gameObject.AddComponent<strongrege>();
        body.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
        body.GetComponent<PhysicalBehaviour>().OverrideImpactSounds = new AudioClip[]
      {
                                    ModAPI.LoadSound("Sound/a1.wav"),
                                    ModAPI.LoadSound("Sound/a2.wav"),
                                    ModAPI.LoadSound("Sound/a3.wav"),
                                    ModAPI.LoadSound("Sound/a4.wav"),
                                    ModAPI.LoadSound("Sound/a5.wav"),
                                    ModAPI.LoadSound("Sound/a6.wav"),
                                    ModAPI.LoadSound("Sound/a1.wav"),
                                    ModAPI.LoadSound("Sound/a2.wav"),
                                    ModAPI.LoadSound("Sound/a3.wav"),
      };

      UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
      useEventTrigger2.Event = new UnityEvent();
      useEventTrigger2.Event.AddListener(delegate ()
       {
         Audio3.Play();
      });

                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Sanji Raid suit",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Sanji Raid suitsd,Raid Suits are special, technologically-enhanced outfits designed for combat.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Sanji Raid suitthumb.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Sanji Raid suit.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.2f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");


Lower.gameObject.AddComponent<kenbun>();
   foot1.gameObject.AddComponent<Firebeh>();
   foot2.gameObject.AddComponent<Firebeh>();

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.3f;
        body.Health *= 1000f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1f;
        body.gameObject.AddComponent<strongrege>();
        UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });

        UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger2.Event = new UnityEvent();
        useEventTrigger2.Event.AddListener(delegate ()
         {
           Audio3.Play();
        });

      var ca = new GameObject("Sanji Raid Suithair");
      ca.transform.SetParent(Instance.transform.Find("Head"));
      ca.transform.localPosition = new Vector3(0, 0f);
      ca.transform.localScale = new Vector3(1f, 1f);
      var caSprite = ca.AddComponent<SpriteRenderer>();
      caSprite.sprite = ModAPI.LoadSprite("image/Sanji Raid Suithair.png",2f);
      ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
      ca.AddComponent<UseEventTrigger>().Action = () => {
      caSprite.sprite = ModAPI.LoadSprite("none.png");
      };

      var backpack = new GameObject("Sanji Raid suitcape");
      backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
      backpack.transform.localPosition = new Vector3(0, 0f);
      backpack.transform.localScale = new Vector3(1f, 1f);
      var backpackSprite = backpack.AddComponent<SpriteRenderer>();
      backpackSprite.sprite = ModAPI.LoadSprite("image/Sanji Raid suitcape.png");
      backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
      backpack.AddComponent<UseEventTrigger>().Action = () => {
      backpackSprite.sprite = ModAPI.LoadSprite("none.png");

     };

      var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
      var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");

      ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Tony Tony Chopper",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Tony Tony Chopper, also known as Cotton Candy Lover, Chopper is the doctor of the Straw Hat Pirates. He is the sixth member of the crew and the fifth to join, doing so at the end of the Drum Island Arc.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Tony Tony Chopperthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Tony Tony Chopper.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");
   var head = Instance.transform.Find("Head");

   head.transform.localScale = new Vector3(1.2f, 1.2f);
   head.transform.localPosition = new Vector3(0.001f, 0.75f);


   var person = Instance.GetComponent<PersonBehaviour>();
   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 1f;
        body.Health *= 10f;
        body.BreakingThreshold *= 1f;
        body.transform.root.localScale *= 0.98f;

        //Tony Tony Chopperhat
          var ca = new GameObject("Tony Tony Chopperhat");
          ca.transform.SetParent(Instance.transform.Find("Head"));
          ca.transform.localPosition = new Vector3(0, 0f);
          ca.transform.localScale = new Vector3(1f, 1f);
          var caSprite = ca.AddComponent<SpriteRenderer>();
          caSprite.sprite = ModAPI.LoadSprite("image/Tony Tony Chopperhat.png");
          ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
          ca.AddComponent<UseEventTrigger>().Action = () => {
          caSprite.sprite = ModAPI.LoadSprite("none.png");
        };

        //Tony Tony Chopperbag
         var backpack = new GameObject("Tony Tony Chopperbag");
         backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
         backpack.transform.localPosition = new Vector3(0, 0f);
         backpack.transform.localScale = new Vector3(1f, 1f);
         var backpackSprite = backpack.AddComponent<SpriteRenderer>();
         backpackSprite.sprite = ModAPI.LoadSprite("image/Tony Tony Chopperbag.png");
         backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
         backpack.AddComponent<UseEventTrigger>().Action = () => {
         backpackSprite.sprite = ModAPI.LoadSprite("none.png");

                                                                };



                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Android"),
   NameOverride = "Chopper monster point",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "This form can be powerful.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/ChopperM.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Chopper monster point.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var leg1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.4f, 1.2f);
   middle.transform.localScale = new Vector3(1.3f, 1.2f);
   Lower.transform.localScale = new Vector3(1.2f, 1f);
   arm3.transform.localScale = new Vector3(1.14f, 1.1f);
   arm4.transform.localScale = new Vector3(1.14f, 1.1f);
   arm1.transform.localScale = new Vector3(1.14f, 1.1f);
   arm2.transform.localScale = new Vector3(1.14f, 1.1f);
   leg3.transform.localScale = new Vector3(1.2f, 1f);
   leg4.transform.localScale = new Vector3(1.2f, 1f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);

   arm3.transform.localPosition = new Vector3(0f, -0.12f);
   arm4.transform.localPosition = new Vector3(0f, -0.12f);
   arm1.transform.localPosition = new Vector3(0f, -0.54f);
   arm2.transform.localPosition = new Vector3(0f, -0.54f);

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 1f;
        body.Health *= 100f;
        body.BreakingThreshold *= 100f;
        body.transform.root.localScale *= 1.07f;
        body.PhysicalBehaviour.BurningProgressionMultiplier = -1000000;
        body.gameObject.AddComponent<strongrege>();
        body.GetComponent<PhysicalBehaviour>().OverrideImpactSounds = new AudioClip[]
      {
                                    ModAPI.LoadSound("Sound/a1.wav"),
                                    ModAPI.LoadSound("Sound/a2.wav"),
                                    ModAPI.LoadSound("Sound/a3.wav"),
                                    ModAPI.LoadSound("Sound/a4.wav"),
                                    ModAPI.LoadSound("Sound/a5.wav"),
                                    ModAPI.LoadSound("Sound/a6.wav"),
                                    ModAPI.LoadSound("Sound/a1.wav"),
                                    ModAPI.LoadSound("Sound/a2.wav"),
                                    ModAPI.LoadSound("Sound/a3.wav"),
                                  };



    //Cmphat
      var ca = new GameObject("Cmphat");
      ca.transform.SetParent(Instance.transform.Find("Head"));
      ca.transform.localPosition = new Vector3(0, 0f);
      ca.transform.localScale = new Vector3(1f, 1f);
      var caSprite = ca.AddComponent<SpriteRenderer>();
      caSprite.sprite = ModAPI.LoadSprite("image/Cmphat.png");
      ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ca.AddComponent<UseEventTrigger>().Action = () => {
      caSprite.sprite = ModAPI.LoadSprite("none.png");
    };

    var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
    var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


    ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
    ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";


                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Nico Robin",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Nico Robin, also known by her epithet Devil Child and the Light of the Revolution, is the archaeologist of the Straw Hat Pirates. She is the seventh member of the crew and the sixth to join.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Nico Robinthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Nico Robin.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   arm3.transform.localScale = new Vector3(1.10f, 1.2f);
   arm4.transform.localScale = new Vector3(1.10f, 1.2f);
   arm1.transform.localScale = new Vector3(1.10f, 1.2f);
   arm2.transform.localScale = new Vector3(1.10f, 1.2f);
   leg3.transform.localScale = new Vector3(1.12f, 1.2f);
   leg4.transform.localScale = new Vector3(1.12f, 1.2f);
   leg1.transform.localScale = new Vector3(1.12f, 1.2f);
   leg2.transform.localScale = new Vector3(1.12f, 1.2f);
   foot1.transform.localScale = new Vector3(1.12f, 1.2f);
   foot2.transform.localScale = new Vector3(1.12f, 1.2f);

   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.01f, 0.67f);

   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.064f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.064f, -1.2513f);

   arm1.gameObject.AddComponent<UseEventTrigger>().Action = () =>
   {
       GameObject Projectile = GameObject.Instantiate(ModAPI.FindSpawnable("hanafist").Prefab);
       CatalogBehaviour.PerformMod(ModAPI.FindSpawnable("hanafist"), Projectile);
       Projectile.transform.rotation = arm1.transform.rotation;
       Projectile.transform.eulerAngles += new Vector3(0, 0, -90);
       Projectile.gameObject.GetComponent<PhysicalBehaviour>().SpawnSpawnParticles = false;
       Projectile.transform.position = arm1.transform.position + (-arm1.transform.up * 1.3f);
       Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(Projectile.transform.right * 1000);
       Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(-Projectile.transform.right * -1000);
       var col = Projectile.AddComponent<NoCollide>();
       col.NoCollideSetA = Projectile.GetComponents<Collider2D>();
       col.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();
       Destroy(Projectile, 0.200f);
   };

   arm2.gameObject.AddComponent<UseEventTrigger>().Action = () =>
   {
       GameObject Projectile = GameObject.Instantiate(ModAPI.FindSpawnable("hanafist").Prefab);
       CatalogBehaviour.PerformMod(ModAPI.FindSpawnable("hanafist"), Projectile);
       Projectile.transform.rotation = arm2.transform.rotation;
       Projectile.transform.eulerAngles += new Vector3(0, 0, -90);
       Projectile.gameObject.GetComponent<PhysicalBehaviour>().SpawnSpawnParticles = false;
       Projectile.transform.position = arm2.transform.position + (-arm2.transform.up * 1.3f);
       Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(Projectile.transform.right * 1000);
       Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(-Projectile.transform.right * -1000);
       var col = Projectile.AddComponent<NoCollide>();
       col.NoCollideSetA = Projectile.GetComponents<Collider2D>();
       col.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();
       Destroy(Projectile, 0.200f);
   };

   var person = Instance.GetComponent<PersonBehaviour>();
   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 1f;
        body.Health *= 1000f;
        body.BreakingThreshold *= 1f;
        body.transform.root.localScale *= 1f;

        var bodyuper = Instance.transform.Find("Body").Find("UpperBody");
        bodyuper.localPosition = new Vector3(0.0f, 0.4f);

        Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/robinbreast.png");
        Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().material.SetTexture("_FleshTex", ModAPI.LoadTexture("image/Fleshbreast.png"));
        Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().material.SetTexture("_BoneTex", ModAPI.LoadTexture("image/Bonebreast.png"));

        var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
        var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");

        ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";
        ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";

        var ornamentobject = new GameObject("robinhair2.png");
        ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
        ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
        ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        ornamentobject.transform.localScale = new Vector3(1f, 1f);
        var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
        ornamentsprite.sprite = ModAPI.LoadSprite("image/robinhair2.png",2f);
        ornamentsprite.sortingLayerName = "Top";

        var ca = new GameObject("robinhair");
        ca.transform.SetParent(Instance.transform.Find("Head"));
        ca.transform.localPosition = new Vector3(0, 0f);
        ca.transform.localScale = new Vector3(1f, 1f);
        var caSprite = ca.AddComponent<SpriteRenderer>();
        caSprite.sprite = ModAPI.LoadSprite("image/robinhair.png",2.5f);
        ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
        ca.AddComponent<UseEventTrigger>().Action = () => {
        caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                          };

                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Android"),
   NameOverride = "Franky",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Iron Man, Franky is the shipwright of the Straw Hat Pirates. He is the crew's eighth member and the seventh to join, doing so at the end of the Post-Enies Lobby Arc.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Frankythumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Franky.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");
   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var leg1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.5f, 1.2f);
   middle.transform.localScale = new Vector3(1.4f, 1.2f);
   Lower.transform.localScale = new Vector3(1.3f, 1.2f);
   arm3.transform.localScale = new Vector3(1.7f, 1.2513f);
   arm4.transform.localScale = new Vector3(1.7f, 1.2513f);
   arm1.transform.localScale = new Vector3(1.7f, 1.3f);
   arm2.transform.localScale = new Vector3(1.7f, 1.3f);
   leg3.transform.localScale = new Vector3(1.3f, 1f);
   leg4.transform.localScale = new Vector3(1.3f, 1f);

   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);

   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.61f);
   arm2.transform.localPosition = new Vector3(0f, -0.61f);

   var person = Instance.GetComponent<PersonBehaviour>();
   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 1f;
        body.Health *= 100f;
        body.BreakingThreshold *= 1f;
        body.transform.root.localScale *= 1.01f;



                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Brook",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Soul King Brook, is the musician of the Straw Hat Pirates, and one of their two swordsmen. He is the ninth member of the crew and the eighth to join doing so at the end of the Thriller Bark Arc.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Brookthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Brook.png");
   var flesh = ModAPI.LoadTexture("image/Brook.png");
   var bone = ModAPI.LoadTexture("Bone.png");
   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.2f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.12f, 1.2f);
   leg4.transform.localScale = new Vector3(1.12f, 1.2f);
   leg1.transform.localScale = new Vector3(1.12f, 1.2f);
   leg2.transform.localScale = new Vector3(1.12f, 1.2f);
   foot1.transform.localScale = new Vector3(1.12f, 1.2f);
   foot2.transform.localScale = new Vector3(1.12f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.064f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.064f, -1.2513f);

   arm1.gameObject.AddComponent<yominomi>();
   arm2.gameObject.AddComponent<yominomi>();

   var person = Instance.GetComponent<PersonBehaviour>();
   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.8f;
        body.Health *= 100f;
        body.BreakingThreshold *= 1f;
        body.transform.root.localScale *= 1.01f;
        body.IsAndroid = true;
        body.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
        body.GetComponent<PhysicalBehaviour>().OverrideImpactSounds = new AudioClip[]
      {
                                    ModAPI.LoadSound("Sound/a1.wav"),
                                    ModAPI.LoadSound("Sound/a2.wav"),
                                    ModAPI.LoadSound("Sound/a3.wav"),
                                    ModAPI.LoadSound("Sound/a4.wav"),
                                    ModAPI.LoadSound("Sound/a5.wav"),
                                    ModAPI.LoadSound("Sound/a6.wav"),
                                    ModAPI.LoadSound("Sound/a1.wav"),
                                    ModAPI.LoadSound("Sound/a2.wav"),
                                    ModAPI.LoadSound("Sound/a3.wav"),
                                  };

        //Brookitem
          var ca = new GameObject("Brookitem.png");
          ca.transform.SetParent(Instance.transform.Find("Head"));
          ca.transform.localPosition = new Vector3(0, 0f);
          ca.transform.localScale = new Vector3(1f, 1f);
          var caSprite = ca.AddComponent<SpriteRenderer>();
          caSprite.sprite = ModAPI.LoadSprite("image/Brookitem.png");
          ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
          ca.AddComponent<UseEventTrigger>().Action = () => {
          caSprite.sprite = ModAPI.LoadSprite("none.png");
          };

          person.SetBodyTextures(skin, flesh, bone, 1);
          person.SetBruiseColor(255, 255, 255);
          person.SetSecondBruiseColor(204, 204, 204);
          person.SetThirdBruiseColor(255, 255, 255);
          person.SetBloodColour(204, 204, 204);
          person.SetRottenColour(255, 255, 255);


                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Jinbe",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Knight of the Sea, Jinbeis the helmsman of the Straw Hat Pirates. He is the tenth member of the crew and the ninth to join, doing so during the Wano Country Arc.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/jinbethumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Jinbe.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var leg1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.4f, 1.2f);
   middle.transform.localScale = new Vector3(1.3f, 1.2f);
   Lower.transform.localScale = new Vector3(1.2f, 1f);
   arm3.transform.localScale = new Vector3(1.15f, 1.1f);
   arm4.transform.localScale = new Vector3(1.14f, 1.1f);
   arm1.transform.localScale = new Vector3(1.14f, 1.1f);
   arm2.transform.localScale = new Vector3(1.14f, 1.1f);
   leg3.transform.localScale = new Vector3(1.2f, 1f);
   leg4.transform.localScale = new Vector3(1.2f, 1f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);

   arm3.transform.localPosition = new Vector3(0f, -0.12f);
   arm4.transform.localPosition = new Vector3(0f, -0.12f);
   arm1.transform.localPosition = new Vector3(0f, -0.54f);
   arm2.transform.localPosition = new Vector3(0f, -0.54f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   Lower.gameObject.AddComponent<kenbun>();
   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.3f;
        body.Health *= 1000f;
        body.BreakingThreshold *= 100f;
        body.transform.root.localScale *= 1.03f;
        body.IsAndroid = true;
        body.gameObject.AddComponent<strongrege>();
        UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });

        UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger2.Event = new UnityEvent();
        useEventTrigger2.Event.AddListener(delegate ()
         {
           Audio3.Play();
        });


    //jinbehair
      var ca = new GameObject("jinbehair");
      ca.transform.SetParent(Instance.transform.Find("Head"));
      ca.transform.localPosition = new Vector3(0, 0f);
      ca.transform.localScale = new Vector3(1f, 1f);
      var caSprite = ca.AddComponent<SpriteRenderer>();
      caSprite.sprite = ModAPI.LoadSprite("image/jinbehair.png");
      ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
      ca.AddComponent<UseEventTrigger>().Action = () => {
      caSprite.sprite = ModAPI.LoadSprite("none.png");

     };

     //cape20
      var backpack = new GameObject("cape20");
      backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
      backpack.transform.localPosition = new Vector3(0, 0f);
      backpack.transform.localScale = new Vector3(1f, 1f);
      var backpackSprite = backpack.AddComponent<SpriteRenderer>();
      backpackSprite.sprite = ModAPI.LoadSprite("image/cape20.png");
      backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
      backpack.AddComponent<UseEventTrigger>().Action = () => {
      backpackSprite.sprite = ModAPI.LoadSprite("none.png");

                                                              };

      person.SetBodyTextures(skin, flesh, bone, 1);
      person.SetBruiseColor(000, 000, 000); //main bruise colour. purple-ish by default
      person.SetSecondBruiseColor(000, 000, 000); //second bruise colour. red by default
      person.SetThirdBruiseColor(000, 000, 000); // third bruise colour. light yellow by default
      person.SetBloodColour(000, 000, 000); // blood clour. dark red by default
      person.SetRottenColour(000, 000, 000); // rotten/zombie colour. light yellow/green by default




                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Yamato",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Yamato is the daughter of Kaido of the Four Emperors and proclaims to be Kozuki Oden,and she is widely referred to as Kaido's son.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/yamatothumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Yamato.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");


   arm3.transform.localScale = new Vector3(1.10f, 1.2f);
   arm4.transform.localScale = new Vector3(1.10f, 1.2f);
   arm1.transform.localScale = new Vector3(1.10f, 1.2f);
   arm2.transform.localScale = new Vector3(1.10f, 1.2f);
   leg3.transform.localScale = new Vector3(1.12f, 1.2f);
   leg4.transform.localScale = new Vector3(1.12f, 1.2f);
   leg1.transform.localScale = new Vector3(1.12f, 1.2f);
   leg2.transform.localScale = new Vector3(1.12f, 1.2f);
   foot1.transform.localScale = new Vector3(1.12f, 1.2f);
   foot2.transform.localScale = new Vector3(1.12f, 1.2f);

   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.01f, 0.67f);

   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.064f, -1.251313f);
   foot2.transform.localPosition = new Vector3(0.064f, -1.251313f);

   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio1 = Instance.AddComponent<AudioSource>();
   Audio1.maxDistance = 100;
   Audio1.loop = false;
   Audio1.clip = ModAPI.LoadSound("Sound/yamatorug.mp3");

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");


   head.gameObject.AddComponent<hao>();
   Lower.gameObject.AddComponent<kenbun>();
   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
       body.BaseStrength *= 0.6f;
       body.Health *= 1000f;
       body.BreakingThreshold *= 10000f;
       body.IsAndroid = true;
       body.transform.root.localScale *= 1.02f;
       body.gameObject.AddComponent<strongrege>();
     var bodyuper = Instance.transform.Find("Body").Find("UpperBody");
     bodyuper.localPosition = new Vector3(0.0f, 0.4f);

     UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
     useEventTrigger0.Event = new UnityEvent();
     useEventTrigger0.Event.AddListener(delegate ()
      {
        ModAPI.CreateParticleEffect("Vapor", head.transform.position);
       Audio2.Play();
     });
     UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
     useEventTrigger.Event = new UnityEvent();
     useEventTrigger.Event.AddListener(delegate ()
      {
       body.ImmuneToDamage = true;
       arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
       arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
       arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
       arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
       Audio.Play();
       Audio1.Play();
     });

     UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
     useEventTrigger1.Event = new UnityEvent();
     useEventTrigger1.Event.AddListener(delegate ()
      {
        body.ImmuneToDamage = false;
        arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
        arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
        arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        Audio.Play();
     });


     UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
     useEventTrigger2.Event = new UnityEvent();
     useEventTrigger2.Event.AddListener(delegate ()
      {
        Audio3.Play();
     });

             Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/yamatobreast.png");
             Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().material.SetTexture("_FleshTex", ModAPI.LoadTexture("image/Fleshbreast.png"));
             Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().material.SetTexture("_BoneTex", ModAPI.LoadTexture("image/Bonebreast.png"));

             var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
             var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");

             ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";
             ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";


       var ca = new GameObject("Yamatohair1");
       ca.transform.SetParent(Instance.transform.Find("Head"));
       ca.transform.localPosition = new Vector3(0, 0f);
       ca.transform.localScale = new Vector3(1f, 1f);
       var caSprite = ca.AddComponent<SpriteRenderer>();
       caSprite.sprite = ModAPI.LoadSprite("image/Yamatohair1.png",4f);
       ca.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";
       ca.AddComponent<UseEventTrigger>().Action = () => {
       caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                         };

      var backpack = new GameObject("yamatoknot");
      backpack.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
      backpack.transform.localPosition = new Vector3(0, 0f);
      backpack.transform.localScale = new Vector3(1f, 1f);
      var backpackSprite = backpack.AddComponent<SpriteRenderer>();
      backpackSprite.sprite = ModAPI.LoadSprite("image/yamatoknot.png");
      backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
      backpack.AddComponent<UseEventTrigger>().Action = () => {
      backpackSprite.sprite = ModAPI.LoadSprite("none.png");
     };

     var ca2 = new GameObject("yamatocape");
     ca2.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
     ca2.transform.localPosition = new Vector3(0, 0f);
     ca2.transform.localScale = new Vector3(1f, 1f);
     var ca2Sprite = ca2.AddComponent<SpriteRenderer>();
     ca2Sprite.sprite = ModAPI.LoadSprite("image/yamatocape.png");
     ca2.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
     ca2.AddComponent<UseEventTrigger>().Action = () => {
     ca2Sprite.sprite = ModAPI.LoadSprite("none.png");
     };


           }
        }
      }
);
ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Ulti",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Ulti is one of the Tobiroppo, the six strongest Shinuchi of the Beasts Pirates. She is the elder sister of fellow Tobiroppo Page One.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Ultithumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Ulti.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   arm3.transform.localScale = new Vector3(1.10f, 1.2f);
   arm4.transform.localScale = new Vector3(1.10f, 1.2f);
   arm1.transform.localScale = new Vector3(1.10f, 1.2f);
   arm2.transform.localScale = new Vector3(1.10f, 1.2f);
   leg3.transform.localScale = new Vector3(1.12f, 1.2f);
   leg4.transform.localScale = new Vector3(1.12f, 1.2f);
   leg1.transform.localScale = new Vector3(1.12f, 1.2f);
   leg2.transform.localScale = new Vector3(1.12f, 1.2f);
   foot1.transform.localScale = new Vector3(1.12f, 1.2f);
   foot2.transform.localScale = new Vector3(1.12f, 1.2f);

   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.01f, 0.67f);

   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.064f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.064f, -1.2513f);


   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");


   head.gameObject.AddComponent<Busoshoku>();
   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();
   leg1.gameObject.AddComponent<Busoshoku>();
   leg2.gameObject.AddComponent<Busoshoku>();

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
       body.BaseStrength *= 0.2f;
       body.Health *= 1000f;
       body.BreakingThreshold *= 1f;
       body.IsAndroid = true;
       body.transform.root.localScale *= 1f;
       body.gameObject.AddComponent<strongrege>();
       UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger.Event = new UnityEvent();
       useEventTrigger.Event.AddListener(delegate ()
        {
         body.ImmuneToDamage = true;
         head.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         head.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.5f, 0.5f, 0.5f, 1f);
         Audio.Play();
       });

       UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger1.Event = new UnityEvent();
       useEventTrigger1.Event.AddListener(delegate ()
        {
          body.ImmuneToDamage = false;
          head.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          head.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          Audio.Play();
       });
     var bodyuper = Instance.transform.Find("Body").Find("UpperBody");
     bodyuper.localPosition = new Vector3(0.0f, 0.4f);

             Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/ultibreast.png");
             Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().material.SetTexture("_FleshTex", ModAPI.LoadTexture("image/Fleshbreast.png"));
             Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().material.SetTexture("_BoneTex", ModAPI.LoadTexture("image/Bonebreast.png"));




             //Ultihair
      var ca = new GameObject("Ultihair");
      ca.transform.SetParent(Instance.transform.Find("Head"));
      ca.transform.localPosition = new Vector3(0, 0f);
      ca.transform.localScale = new Vector3(1f, 1f);
      var caSprite = ca.AddComponent<SpriteRenderer>();
      caSprite.sprite = ModAPI.LoadSprite("image/Ultihair.png",2.5f);
      ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ca.AddComponent<UseEventTrigger>().Action = () => {
      caSprite.sprite = ModAPI.LoadSprite("none.png");
        };


      //cape21
       var backpack = new GameObject("cape21");
       backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
       backpack.transform.localPosition = new Vector3(0, 0f);
       backpack.transform.localScale = new Vector3(1f, 1f);
       var backpackSprite = backpack.AddComponent<SpriteRenderer>();
       backpackSprite.sprite = ModAPI.LoadSprite("image/cape21.png");
       backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
       backpack.AddComponent<UseEventTrigger>().Action = () => {
       backpackSprite.sprite = ModAPI.LoadSprite("none.png");

                                                                };

      var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
      var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");

      ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";


           }
        }
      }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Uta",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Uta, also known as Diva, is a world-famous singer and the daughter of Red-Haired Shanks, formerly being a musician in his crew, the Red Hair Pirates, until he left her while she was still a child.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Utathumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Uta.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");


   arm3.transform.localScale = new Vector3(1.10f, 1.2f);
   arm4.transform.localScale = new Vector3(1.10f, 1.2f);
   arm1.transform.localScale = new Vector3(1.10f, 1.2f);
   arm2.transform.localScale = new Vector3(1.10f, 1.2f);
   leg3.transform.localScale = new Vector3(1.12f, 1.2f);
   leg4.transform.localScale = new Vector3(1.12f, 1.2f);
   leg1.transform.localScale = new Vector3(1.12f, 1.2f);
   leg2.transform.localScale = new Vector3(1.12f, 1.2f);
   foot1.transform.localScale = new Vector3(1.12f, 1.2f);
   foot2.transform.localScale = new Vector3(1.12f, 1.2f);

   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.01f, 0.67f);

   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.064f, -1.251313f);
   foot2.transform.localPosition = new Vector3(0.064f, -1.251313f);

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   Lower.gameObject.AddComponent<kenbun>();

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
       body.BaseStrength *= 0.1f;
       body.Health *= 1000f;
       body.BreakingThreshold *= 1f;
       body.IsAndroid = true;
       body.transform.root.localScale *= 1f;
       body.gameObject.AddComponent<strongrege>();

       var Hand = new GameObject("Hand");
       Hand.transform.SetParent(Instance.transform.Find("BackArm").Find("UpperArm"));
       Hand.transform.localPosition = new Vector3(0, 0f);
       Hand.transform.localScale = new Vector3(1f, 1f);
       var HandSprite = Hand.AddComponent<SpriteRenderer>();
       HandSprite.sprite = ModAPI.LoadSprite("image/Utaarm2.png");
       HandSprite.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";

       var Up = new GameObject("Up");
       Up.transform.SetParent(Instance.transform.Find("BackArm").Find("LowerArm"));
       Up.transform.localPosition = new Vector3(0, 0f);
       Up.transform.localScale = new Vector3(1f, 1f);
       var UpSprite = Up.AddComponent<SpriteRenderer>();
       UpSprite.sprite = ModAPI.LoadSprite("image/Utaarm1.png");
       Up.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";

     var bodyuper = Instance.transform.Find("Body").Find("UpperBody");
     bodyuper.localPosition = new Vector3(0.0f, 0.4f);



     UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
     useEventTrigger2.Event = new UnityEvent();
     useEventTrigger2.Event.AddListener(delegate ()
      {
        Audio3.Play();
     });

             Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/utabreast.png");
             Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().material.SetTexture("_FleshTex", ModAPI.LoadTexture("image/Fleshbreast.png"));
             Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().material.SetTexture("_BoneTex", ModAPI.LoadTexture("image/Bonebreast.png"));


             var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
             var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");

             ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";
             ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";


       var ca = new GameObject("Utahair1");
       ca.transform.SetParent(Instance.transform.Find("Head"));
       ca.transform.localPosition = new Vector3(0, 0f);
       ca.transform.localScale = new Vector3(1f, 1f);
       var caSprite = ca.AddComponent<SpriteRenderer>();
       caSprite.sprite = ModAPI.LoadSprite("image/Utahair1.png",2.5f);
       ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
       ca.AddComponent<UseEventTrigger>().Action = () => {
       caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                         };

      var backpack = new GameObject("Utawing");
      backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
      backpack.transform.localPosition = new Vector3(0, 0f);
      backpack.transform.localScale = new Vector3(1f, 1f);
      var backpackSprite = backpack.AddComponent<SpriteRenderer>();
      backpackSprite.sprite = ModAPI.LoadSprite("image/Utawing.png",2f);
      backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Backgruond";
      backpack.AddComponent<UseEventTrigger>().Action = () => {
      backpackSprite.sprite = ModAPI.LoadSprite("none.png");
     };





           }
        }
      }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Shirahoshi",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Princess Shirahoshi, famous in the world as the Mermaid Princess is a giant smelt-whiting mermaid and the princess of the Ryugu Kingdom, as the youngest of King Neptune's children in the Neptune royal family.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Shirahoshithumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Shirahoshi.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   arm3.transform.localScale = new Vector3(1.10f, 1.2f);
   arm4.transform.localScale = new Vector3(1.10f, 1.2f);
   arm1.transform.localScale = new Vector3(1.10f, 1.2f);
   arm2.transform.localScale = new Vector3(1.10f, 1.2f);
   leg3.transform.localScale = new Vector3(1.6f, 1.2f);
   leg4.transform.localScale = new Vector3(1.6f, 1.2f);
   leg1.transform.localScale = new Vector3(1.5f, 1.2f);
   leg2.transform.localScale = new Vector3(1.5f, 1.2f);
   foot1.transform.localScale = new Vector3(1.5f, 1.4f);
   foot2.transform.localScale = new Vector3(1.5f, 1.4f);

   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.01f, 0.67f);

   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.01f, -1.251313f);
   foot2.transform.localPosition = new Vector3(0.01f, -1.251313f);

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   Lower.gameObject.AddComponent<kenbun>();

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
       body.BaseStrength *= 0.5f;
       body.Health *= 1000f;
       body.BreakingThreshold *= 1f;
       body.IsAndroid = true;
       body.Wince(0f);
       body.DoStumble = true;
       body.DoBalanceJerk = true;
       body.transform.root.localScale *= 1.11f;
       body.gameObject.AddComponent<strongrege>();

     var bodyuper = Instance.transform.Find("Body").Find("UpperBody");
     bodyuper.localPosition = new Vector3(0.0f, 0.4f);



     UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
     useEventTrigger2.Event = new UnityEvent();
     useEventTrigger2.Event.AddListener(delegate ()
      {
        Audio3.Play();
     });

             Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/Shirahoshibreast.png");
             Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().material.SetTexture("_FleshTex", ModAPI.LoadTexture("image/Fleshbreast.png"));
             Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().material.SetTexture("_BoneTex", ModAPI.LoadTexture("image/Bonebreast.png"));

             Instance.transform.Find("FrontLeg").Find("FootFront").GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/Shirahoshifoot.png");
             Instance.transform.Find("FrontLeg").Find("FootFront").GetComponent<SpriteRenderer>().material.SetTexture("_FleshTex", ModAPI.LoadTexture("image/Shirahoshimeatfoot.png"));
             Instance.transform.Find("FrontLeg").Find("FootFront").GetComponent<SpriteRenderer>().material.SetTexture("_BoneTex", ModAPI.LoadTexture("image/Shirahoshibonefoot.png"));

             var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
             var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");

             ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";
             ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";


       var ca = new GameObject("Shirahoshihair");
       ca.transform.SetParent(Instance.transform.Find("Head"));
       ca.transform.localPosition = new Vector3(0, 0f);
       ca.transform.localScale = new Vector3(1f, 1f);
       var caSprite = ca.AddComponent<SpriteRenderer>();
       caSprite.sprite = ModAPI.LoadSprite("image/Shirahoshihair.png",2.5f);
       ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
       ca.AddComponent<UseEventTrigger>().Action = () => {
       caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                         };

      var backpack = new GameObject("Shirahoshisuit");
      backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
      backpack.transform.localPosition = new Vector3(0, 0f);
      backpack.transform.localScale = new Vector3(1f, 1f);
      var backpackSprite = backpack.AddComponent<SpriteRenderer>();
      backpackSprite.sprite = ModAPI.LoadSprite("image/Shirahoshisuit.png");
      backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";
      backpack.AddComponent<UseEventTrigger>().Action = () => {
      backpackSprite.sprite = ModAPI.LoadSprite("none.png");
     };

     var ornamentobject2 = new GameObject("Shirahoshico2.png");
     ornamentobject2.transform.SetParent(Instance.transform.Find("FrontLeg").Find("LowerLegFront"));
     ornamentobject2.transform.localPosition = new Vector3(0f, 0f);
     ornamentobject2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
     ornamentobject2.transform.localScale = new Vector3(1f, 1f);
     var ornamentsprite2 = ornamentobject2.AddComponent<SpriteRenderer>();
     ornamentsprite2.sprite = ModAPI.LoadSprite("image/Shirahoshico2.png");
     ornamentsprite2.sortingLayerName = "Middle";

     var ornamentobject3 = new GameObject("Shirahoshico1.png");
     ornamentobject3.transform.SetParent(Instance.transform.Find("FrontLeg").Find("UpperLegFront"));
     ornamentobject3.transform.localPosition = new Vector3(0f, 0f);
     ornamentobject3.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
     ornamentobject3.transform.localScale = new Vector3(1f, 1f);
     var ornamentsprite3 = ornamentobject3.AddComponent<SpriteRenderer>();
     ornamentsprite3.sprite = ModAPI.LoadSprite("image/Shirahoshico1.png");
     ornamentsprite3.sortingLayerName = "Middle";




     Instance.transform.Find("BackLeg").Find("LowerLeg").gameObject.GetComponent<PhysicalBehaviour>().Disintegrate();
     Instance.transform.Find("BackLeg").Find("UpperLeg").gameObject.GetComponent<PhysicalBehaviour>().Disintegrate();
     Instance.transform.Find("BackLeg").Find("Foot").gameObject.GetComponent<PhysicalBehaviour>().Disintegrate();

           }
        }
      }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Knife"),
        NameOverride = "Aramakihand",
        NameToOrderByOverride = "ZZZZZZZZZZZZZZ",
        CategoryOverride = ModAPI.FindCategory("Null"),
        ThumbnailOverride = ModAPI.LoadSprite("Darkness.png"),
        AfterSpawn = (Instance) =>
        {

          Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/Aramakihand.png",2f);
          Instance.GetComponent<PhysicalBehaviour>().MakeWeightless();
          Instance.gameObject.AddComponent<Busoshoku>();
          Instance.FixColliders();
          var properties = ModAPI.FindPhysicalProperties("Wood");
          properties.Sharp = true;
        properties.SharpAxes = new SharpAxis[]
          {

            new SharpAxis(Vector2.down, 0f, 0.2f, true, false),
          };
          Instance.GetComponent<PhysicalBehaviour>().Properties = properties;



        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Small I-Beam"),
        NameOverride = "Penta-Chromatic String",
        NameToOrderByOverride = "ZZZZZZZZZZZZZZ",
        CategoryOverride = ModAPI.FindCategory("Null"),
        ThumbnailOverride = ModAPI.LoadSprite("Darkness.png"),
        AfterSpawn = (Instance) =>
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/Penta-Chromatic String.png");
            Instance.GetComponent<PhysicalBehaviour>().MakeWeightless();
            Instance.gameObject.AddComponent<Busoshoku>();
            Instance.FixColliders();
            var properties = ModAPI.FindPhysicalProperties("Metal");
            properties.Sharp = true;
          properties.SharpAxes = new SharpAxis[]
            {
              new SharpAxis(Vector2.right, 0f, 0.01f, true, false),
              new SharpAxis(Vector3.left, 0f, 0.01f, true, false),
              new SharpAxis(Vector2.down, 0f, 0.2f, true, false),
            };
            Instance.GetComponent<PhysicalBehaviour>().Properties = properties;



        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Brick"),
        NameOverride = "Kaidou's full Beast Form",
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "The full dragon form's strength befits its size, as the user can severely damage structures like houses merely by brushing by them.",
        CategoryOverride = ModAPI.FindCategory("One Piece pack"),
        ThumbnailOverride = ModAPI.LoadSprite("Image/Kaido dragon form thumb.png"),
        AfterSpawn = (Instance) =>
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Kaido dragon form head.png",1f);
            Instance.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
            Instance.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
            Instance.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;
            Instance.gameObject.AddComponent<Borobreath>();
            Instance.transform.root.localScale *= 10f;
            Instance.FixColliders();

            AudioSource Audio = Instance.AddComponent<AudioSource>();
            Audio.maxDistance = 10;
            Audio.loop = false;
            Audio.clip = ModAPI.LoadSound("Sound/Kaidobororug.mp3");

            UseEventTrigger useEventTrigger = Instance.gameObject.AddComponent<UseEventTrigger>();
            useEventTrigger.Event = new UnityEvent();
            useEventTrigger.Event.AddListener(delegate ()
             {
               Audio.Play();
               var effect = ModAPI.CreateParticleEffect("Spark", new Vector2(Instance.transform.position.x, Instance.transform.position.y));
               var main = effect.GetComponent<ParticleSystem>().main;main.startColor = new Color(255/255f, 0/255f, 0/255f);
               effect.transform.root.localScale *= 100f;
            });

            var kagu1 = new GameObject("kagu1");
            kagu1 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
            kagu1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
            kagu1.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;

            SpriteRenderer kagu1Renderer = kagu1.GetComponent<SpriteRenderer>();
                        kagu1Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form body.png");
                        kagu1Renderer.sortingLayerName = "Default";
                        foreach (var c in kagu1.GetComponents<Collider2D>())
                        {

                        }
                        kagu1.AddComponent<CircleCollider2D>();
         kagu1.transform.SetParent(Instance.gameObject.transform);

         kagu1.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
         var col = kagu1.AddComponent<NoCollide>();
         col.NoCollideSetA = kagu1.GetComponents<Collider2D>();
         col.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();
        kagu1.transform.localScale = new Vector3(1f, 1f);


                 HingeJoint2D hingeJoint = kagu1.GetOrAddComponent<HingeJoint2D>();
                 hingeJoint.connectedBody = Instance.gameObject.GetComponent<Rigidbody2D>();
                 hingeJoint.anchor = new Vector3(0f, 0f);

                 JointAngleLimits2D limits = hingeJoint.limits;
                 limits.min = 6;
                 limits.max = -6;
                 hingeJoint.limits = limits;
                 hingeJoint.useLimits = true;
       kagu1.transform.localPosition = new Vector3(-2f, 0f);

       var kagu2 = new GameObject("kagu2");
       kagu2 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
               kagu2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
               SpriteRenderer kagu2Renderer = kagu2.GetComponent<SpriteRenderer>();
               kagu2Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form bodycape.png");
               kagu2Renderer.sortingLayerName = "Foreground";


               foreach (var c in kagu2.GetComponents<Collider2D>())
               {

               }
       kagu2.GetComponent<Rigidbody2D>();
               kagu2.AddComponent<BoxCollider2D>();
       kagu2.transform.SetParent(kagu1.gameObject.transform);
       kagu2.transform.localPosition = new Vector3(-2f, 0f);
               kagu2.transform.localScale = new Vector3(1f, 1f);
               kagu2.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;

               kagu2.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
               var col2 = kagu2.AddComponent<NoCollide>();
               col2.NoCollideSetA = kagu2.GetComponents<Collider2D>();
               col2.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

               HingeJoint2D kagu2hingeJoint = kagu2.GetOrAddComponent<HingeJoint2D>();
               kagu2hingeJoint.connectedBody = kagu1.gameObject.GetComponent<Rigidbody2D>();
               kagu2hingeJoint.anchor = new Vector3(0f, 0f);

               JointAngleLimits2D kagu2limits = hingeJoint.limits;
               kagu2limits.min = 5;
               kagu2limits.max = -5;
               kagu2hingeJoint.limits = kagu2limits;
               kagu2hingeJoint.useLimits = true;

var kagu3 = new GameObject("kagu3");
kagu3 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
       kagu3.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
       SpriteRenderer kagu3Renderer = kagu3.GetComponent<SpriteRenderer>();
       kagu3Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form body.png");
       kagu3Renderer.sortingLayerName = "Foreground";

       foreach (var c in kagu3.GetComponents<Collider2D>())
       {

       }
kagu3.GetComponent<Rigidbody2D>();
       kagu3.AddComponent<BoxCollider2D>();
kagu3.transform.SetParent(kagu2.gameObject.transform);
kagu3.transform.localPosition = new Vector3(-2f, 0f);
       kagu3.transform.localScale = new Vector3(1f, 1f);
       kagu3.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;

       kagu3.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
       var col23 = kagu3.AddComponent<NoCollide>();
       col23.NoCollideSetA = kagu3.GetComponents<Collider2D>();
       col23.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

       HingeJoint2D kagu3hingeJoint = kagu3.GetOrAddComponent<HingeJoint2D>();
       kagu3hingeJoint.connectedBody = kagu2.gameObject.GetComponent<Rigidbody2D>();
       kagu3hingeJoint.anchor = new Vector3(0f, 0f);

       JointAngleLimits2D kagu3limits = hingeJoint.limits;
       kagu3limits.min = 5;
       kagu3limits.max = -5;
       kagu3hingeJoint.limits = kagu3limits;
       kagu3hingeJoint.useLimits = true;

       var ornamentobject = new GameObject("Kaidofire");
       ornamentobject.transform.SetParent(kagu2.transform);
       ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
       ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
       ornamentobject.transform.localScale = new Vector3(1f, 1f);
       var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
       ornamentsprite.sprite = ModAPI.LoadSprite("image/Kaidofire.png",1f);
       ornamentsprite.sortingLayerName = "Top";

       var ornamentobject2 = new GameObject("Kaidofire");
       ornamentobject2.transform.SetParent(kagu2.transform);
       ornamentobject2.transform.localPosition = new Vector3(-0.03f, 0.03f);
       ornamentobject2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
       ornamentobject2.transform.localScale = new Vector3(1f, 1f);
       var ornamentsprite2 = ornamentobject2.AddComponent<SpriteRenderer>();
       ornamentsprite2.sprite = ModAPI.LoadSprite("image/Kaidofire.png",1f);
       ornamentsprite2.sortingLayerName = "Backgruond";

       //////////////////////////////////////////////////
          var kaguSup = new GameObject("kaguSup");
          kaguSup = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
                  kaguSup.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
                  SpriteRenderer kaguSupRenderer = kaguSup.GetComponent<SpriteRenderer>();
                  kaguSupRenderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form upperarm.png");
                  kaguSupRenderer.sortingLayerName = "Decals";

                  foreach (var c in kaguSup.GetComponents<Collider2D>())
                  {

                  }
          kaguSup.GetComponent<Rigidbody2D>();
                  kaguSup.AddComponent<BoxCollider2D>();
          kaguSup.transform.SetParent(kagu2.gameObject.transform);
          kaguSup.transform.localPosition = new Vector3(0.7f, -0.8f);
                  kaguSup.transform.localScale = new Vector3(1f, 1f);
                  kaguSup.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;



                  kaguSup.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
                  var colSup = kaguSup.AddComponent<NoCollide>();
                  colSup.NoCollideSetA = kaguSup.GetComponents<Collider2D>();
                  colSup.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

                  HingeJoint2D kaguSuphingeJoint = kaguSup.GetOrAddComponent<HingeJoint2D>();
                  kaguSuphingeJoint.connectedBody = kagu2.gameObject.GetComponent<Rigidbody2D>();
                  kaguSuphingeJoint.anchor = new Vector3(0f, 0f);

                  JointAngleLimits2D kaguSuplimits = hingeJoint.limits;
                  kaguSuplimits.min = 30;
                  kaguSuplimits.max = -60;
                  kaguSuphingeJoint.limits = kaguSuplimits;
           kaguSuphingeJoint.useLimits = true;

           var kaguSup2 = new GameObject("kaguSup2");
           kaguSup2 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
                   kaguSup2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
                   SpriteRenderer kaguSup2Renderer = kaguSup2.GetComponent<SpriteRenderer>();
                   kaguSup2Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form lowerarm.png");
                   kaguSup2Renderer.sortingLayerName = "Decals";

                   foreach (var c in kaguSup2.GetComponents<Collider2D>())
                   {

                   }
           kaguSup2.GetComponent<Rigidbody2D>();
                   kaguSup2.AddComponent<BoxCollider2D>();
           kaguSup2.transform.SetParent(kaguSup.gameObject.transform);
           kaguSup2.transform.localPosition = new Vector3(0.5f, -0.5f);
                   kaguSup2.transform.localScale = new Vector3(1f, 1f);
                   kaguSup2.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;

                   kaguSup2.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
                   var colSup2 = kaguSup2.AddComponent<NoCollide>();
                   colSup2.NoCollideSetA = kaguSup2.GetComponents<Collider2D>();
                   colSup2.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

                   HingeJoint2D kaguSup2hingeJoint = kaguSup2.GetOrAddComponent<HingeJoint2D>();
                   kaguSup2hingeJoint.connectedBody = kaguSup.gameObject.GetComponent<Rigidbody2D>();
                   kaguSup2hingeJoint.anchor = new Vector3(0f, 0f);

                   JointAngleLimits2D kaguSup2limits = hingeJoint.limits;
                   kaguSup2limits.min = 5;
                   kaguSup2limits.max = -5;
                   kaguSup2hingeJoint.limits = kaguSup2limits;
            kaguSup2hingeJoint.useLimits = true;

       //0000000000000000000000000000000000000000000000000000000000//

       var kaguSup3 = new GameObject("kaguSup3");
       kaguSup3 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
               kaguSup3.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
               SpriteRenderer kaguSup3Renderer = kaguSup3.GetComponent<SpriteRenderer>();
               kaguSup3Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form upperarmback.png");
               kaguSup3Renderer.sortingLayerName = "Bottom";

               foreach (var c in kaguSup3.GetComponents<Collider2D>())
               {

               }
       kaguSup3.GetComponent<Rigidbody2D>();
               kaguSup3.AddComponent<BoxCollider2D>();
       kaguSup3.transform.SetParent(kagu2.gameObject.transform);
       kaguSup3.transform.localPosition = new Vector3(0.7f, -0.8f);
               kaguSup3.transform.localScale = new Vector3(1f, 1f);
               kaguSup3.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;



               kaguSup3.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
               var colSup3 = kaguSup3.AddComponent<NoCollide>();
               colSup3.NoCollideSetA = kaguSup3.GetComponents<Collider2D>();
               colSup3.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

               HingeJoint2D kaguSup3hingeJoint = kaguSup3.GetOrAddComponent<HingeJoint2D>();
               kaguSup3hingeJoint.connectedBody = kagu2.gameObject.GetComponent<Rigidbody2D>();
               kaguSup3hingeJoint.anchor = new Vector3(0f, 0f);

               JointAngleLimits2D kaguSup3limits = hingeJoint.limits;
               kaguSup3limits.min = 30;
               kaguSup3limits.max = -30;
               kaguSup3hingeJoint.limits = kaguSup3limits;
        kaguSup3hingeJoint.useLimits = true;

        var kaguSup4 = new GameObject("kaguSup");
        kaguSup4 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
                kaguSup2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
                SpriteRenderer kaguSup4Renderer = kaguSup4.GetComponent<SpriteRenderer>();
                kaguSup4Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form lowerarmback.png");
                kaguSup4Renderer.sortingLayerName = "Bottom";

                foreach (var c in kaguSup4.GetComponents<Collider2D>())
                {

                }
        kaguSup4.GetComponent<Rigidbody2D>();
                kaguSup4.AddComponent<BoxCollider2D>();
        kaguSup4.transform.SetParent(kaguSup3.gameObject.transform);
        kaguSup4.transform.localPosition = new Vector3(0.5f, -0.5f);
                kaguSup4.transform.localScale = new Vector3(1f, 1f);
                kaguSup4.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;

                kaguSup4.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
                var colSup4 = kaguSup4.AddComponent<NoCollide>();
                colSup4.NoCollideSetA = kaguSup4.GetComponents<Collider2D>();
                colSup4.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

                HingeJoint2D kaguSup4hingeJoint = kaguSup4.GetOrAddComponent<HingeJoint2D>();
                kaguSup4hingeJoint.connectedBody = kaguSup3.gameObject.GetComponent<Rigidbody2D>();
                kaguSup4hingeJoint.anchor = new Vector3(0f, 0f);

                JointAngleLimits2D kaguSup4limits = hingeJoint.limits;
                kaguSup4limits.min = 5;
                kaguSup4limits.max = -5;
                kaguSup4hingeJoint.limits = kaguSup4limits;
         kaguSup4hingeJoint.useLimits = true;




//////////////////////////////////////////////////////////////

 var kagu4 = new GameObject("kagu4");
 kagu4 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
         kagu4.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         SpriteRenderer kagu4Renderer = kagu4.GetComponent<SpriteRenderer>();
         kagu4Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form body.png");
         kagu4Renderer.sortingLayerName = "Foreground";

         foreach (var c in kagu4.GetComponents<Collider2D>())
         {

         }
 kagu4.GetComponent<Rigidbody2D>();
         kagu4.AddComponent<BoxCollider2D>();
 kagu4.transform.SetParent(kagu3.gameObject.transform);
 kagu4.transform.localPosition = new Vector3(-2, 0f);
         kagu4.transform.localScale = new Vector3(1f, 1f);
         kagu4.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;

         kagu4.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
         var col234 = kagu4.AddComponent<NoCollide>();
         col234.NoCollideSetA = kagu4.GetComponents<Collider2D>();
         col234.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

         HingeJoint2D kagu4hingeJoint = kagu4.GetOrAddComponent<HingeJoint2D>();
         kagu4hingeJoint.connectedBody = kagu3.gameObject.GetComponent<Rigidbody2D>();
         kagu4hingeJoint.anchor = new Vector3(0f, 0f);

         JointAngleLimits2D kagu4limits = hingeJoint.limits;
         kagu4limits.min = 5;
         kagu4limits.max = -5;
         kagu4hingeJoint.limits = kagu4limits;
  kagu4hingeJoint.useLimits = true;

  var kagu5 = new GameObject("kagu5");
  kagu5 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
          kagu5.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          SpriteRenderer kagu5Renderer = kagu5.GetComponent<SpriteRenderer>();
          kagu5Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form body.png");
          kagu5Renderer.sortingLayerName = "Foreground";

          foreach (var c in kagu5.GetComponents<Collider2D>())
          {

          }
  kagu5.GetComponent<Rigidbody2D>();
          kagu5.AddComponent<BoxCollider2D>();
  kagu5.transform.SetParent(kagu4.gameObject.transform);
  kagu5.transform.localPosition = new Vector3(-2f, 0f);
          kagu5.transform.localScale = new Vector3(1f, 1f);
          kagu5.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;

          kagu5.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
          var col2345 = kagu5.AddComponent<NoCollide>();
          col2345.NoCollideSetA = kagu5.GetComponents<Collider2D>();
          col2345.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

          HingeJoint2D kagu5hingeJoint = kagu5.GetOrAddComponent<HingeJoint2D>();
          kagu5hingeJoint.connectedBody = kagu4.gameObject.GetComponent<Rigidbody2D>();
          kagu5hingeJoint.anchor = new Vector3(0f, 0f);

          JointAngleLimits2D kagu5limits = hingeJoint.limits;
          kagu5limits.min = 5;
          kagu5limits.max = -5;
          kagu5hingeJoint.limits = kagu5limits;
   kagu5hingeJoint.useLimits = true;

   var kagu6 = new GameObject("kagu6");
   kagu6 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
           kagu6.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
           SpriteRenderer kagu6Renderer = kagu6.GetComponent<SpriteRenderer>();
           kagu6Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form body.png");
           kagu6Renderer.sortingLayerName = "Foreground";

           foreach (var c in kagu6.GetComponents<Collider2D>())
           {

           }
   kagu6.GetComponent<Rigidbody2D>();
           kagu6.AddComponent<BoxCollider2D>();
   kagu6.transform.SetParent(kagu5.gameObject.transform);
   kagu6.transform.localPosition = new Vector3(-2f, 0f);
           kagu6.transform.localScale = new Vector3(1f, 1f);
           kagu6.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;

           kagu6.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
           var col23456 = kagu6.AddComponent<NoCollide>();
           col23456.NoCollideSetA = kagu6.GetComponents<Collider2D>();
           col23456.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

           HingeJoint2D kagu6hingeJoint = kagu6.GetOrAddComponent<HingeJoint2D>();
           kagu6hingeJoint.connectedBody = kagu5.gameObject.GetComponent<Rigidbody2D>();
           kagu6hingeJoint.anchor = new Vector3(0f, 0f);

           JointAngleLimits2D kagu6limits = hingeJoint.limits;
           kagu6limits.min = 5;
           kagu6limits.max = -5;
           kagu6hingeJoint.limits = kagu6limits;
    kagu6hingeJoint.useLimits = true;

    var kagu7 = new GameObject("kagu7");
    kagu7 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
            kagu7.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
            SpriteRenderer kagu7Renderer = kagu7.GetComponent<SpriteRenderer>();
            kagu7Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form body.png");
            kagu7Renderer.sortingLayerName = "Foreground";

            foreach (var c in kagu7.GetComponents<Collider2D>())
            {

            }
    kagu7.GetComponent<Rigidbody2D>();
            kagu7.AddComponent<BoxCollider2D>();
    kagu7.transform.SetParent(kagu6.gameObject.transform);
    kagu7.transform.localPosition = new Vector3(-2f, 0f);
            kagu7.transform.localScale = new Vector3(1f, 1f);
            kagu7.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;



            kagu7.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
            var col234567 = kagu7.AddComponent<NoCollide>();
            col234567.NoCollideSetA = kagu7.GetComponents<Collider2D>();
            col234567.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

            HingeJoint2D kagu7hingeJoint = kagu7.GetOrAddComponent<HingeJoint2D>();
            kagu7hingeJoint.connectedBody = kagu6.gameObject.GetComponent<Rigidbody2D>();
            kagu7hingeJoint.anchor = new Vector3(0f, 0f);

            JointAngleLimits2D kagu7limits = hingeJoint.limits;
            kagu7limits.min = 5;
            kagu7limits.max = -5;
            kagu7hingeJoint.limits = kagu7limits;
     kagu7hingeJoint.useLimits = true;

     //////////////////////////////////////////////////
        var kaguSup5 = new GameObject("kaguSup");
        kaguSup5 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
                kaguSup5.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
                SpriteRenderer kaguSup5Renderer = kaguSup5.GetComponent<SpriteRenderer>();
                kaguSup5Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form upperarm.png");
                kaguSup5Renderer.sortingLayerName = "Top";

                foreach (var c in kaguSup5.GetComponents<Collider2D>())
                {

                }
        kaguSup5.GetComponent<Rigidbody2D>();
                kaguSup5.AddComponent<BoxCollider2D>();
        kaguSup5.transform.SetParent(kagu7.gameObject.transform);
        kaguSup5.transform.localPosition = new Vector3(0.7f, -0.8f);
                kaguSup5.transform.localScale = new Vector3(1f, 1f);
                kaguSup5.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;

                kaguSup5.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
                var colSup5 = kaguSup5.AddComponent<NoCollide>();
                colSup5.NoCollideSetA = kaguSup5.GetComponents<Collider2D>();
                colSup5.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

                HingeJoint2D kaguSup5hingeJoint = kaguSup5.GetOrAddComponent<HingeJoint2D>();
                kaguSup5hingeJoint.connectedBody = kagu7.gameObject.GetComponent<Rigidbody2D>();
                kaguSup5hingeJoint.anchor = new Vector3(0f, 0f);

                JointAngleLimits2D kaguSup5limits = hingeJoint.limits;
                kaguSup5limits.min = 30;
                kaguSup5limits.max = -60;
                kaguSup5hingeJoint.limits = kaguSup5limits;
         kaguSup5hingeJoint.useLimits = true;

         var kaguSup6 = new GameObject("kaguSup6");
         kaguSup6 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
                 kaguSup6.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
                 SpriteRenderer kaguSup6Renderer = kaguSup6.GetComponent<SpriteRenderer>();
                 kaguSup6Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form lowerarm2.png");
                 kaguSup6Renderer.sortingLayerName = "Top";

                 foreach (var c in kaguSup6.GetComponents<Collider2D>())
                 {

                 }
         kaguSup6.GetComponent<Rigidbody2D>();
                 kaguSup6.AddComponent<BoxCollider2D>();
         kaguSup6.transform.SetParent(kaguSup5.gameObject.transform);
         kaguSup6.transform.localPosition = new Vector3(0.5f, -0.5f);
                 kaguSup6.transform.localScale = new Vector3(1f, 1f);
                 kaguSup6.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;

                 kaguSup6.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
                 var colSup6 = kaguSup6.AddComponent<NoCollide>();
                 colSup6.NoCollideSetA = kaguSup6.GetComponents<Collider2D>();
                 colSup6.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

                 HingeJoint2D kaguSup6hingeJoint = kaguSup6.GetOrAddComponent<HingeJoint2D>();
                 kaguSup6hingeJoint.connectedBody = kaguSup5.gameObject.GetComponent<Rigidbody2D>();
                 kaguSup6hingeJoint.anchor = new Vector3(0f, 0f);

                 JointAngleLimits2D kaguSup6limits = hingeJoint.limits;
                 kaguSup6limits.min = 5;
                 kaguSup6limits.max = -5;
                 kaguSup6hingeJoint.limits = kaguSup6limits;
          kaguSup6hingeJoint.useLimits = true;

     //0000000000000000000000000000000000000000000000000000000000//

     var kaguSup7 = new GameObject("kaguSup");
     kaguSup7 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
             kaguSup5.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
             SpriteRenderer kaguSup7Renderer = kaguSup7.GetComponent<SpriteRenderer>();
             kaguSup7Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form upperarm.png");
             kaguSup7Renderer.sortingLayerName = "Bottom";

             foreach (var c in kaguSup7.GetComponents<Collider2D>())
             {

             }
     kaguSup7.GetComponent<Rigidbody2D>();
             kaguSup7.AddComponent<BoxCollider2D>();
     kaguSup7.transform.SetParent(kagu7.gameObject.transform);
     kaguSup7.transform.localPosition = new Vector3(0.7f, -0.8f);
             kaguSup7.transform.localScale = new Vector3(1f, 1f);
             kaguSup7.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;

             kaguSup7.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
             var colSup7 = kaguSup7.AddComponent<NoCollide>();
             colSup7.NoCollideSetA = kaguSup7.GetComponents<Collider2D>();
             colSup7.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

             HingeJoint2D kaguSup7hingeJoint = kaguSup7.GetOrAddComponent<HingeJoint2D>();
             kaguSup7hingeJoint.connectedBody = kagu7.gameObject.GetComponent<Rigidbody2D>();
             kaguSup7hingeJoint.anchor = new Vector3(0f, 0f);

             JointAngleLimits2D kaguSup7limits = hingeJoint.limits;
             kaguSup7limits.min = 30;
             kaguSup7limits.max = -60;
             kaguSup7hingeJoint.limits = kaguSup7limits;
      kaguSup7hingeJoint.useLimits = true;

      var kaguSup8 = new GameObject("kaguSup8");
      kaguSup8 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
              kaguSup8.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
              SpriteRenderer kaguSup8Renderer = kaguSup8.GetComponent<SpriteRenderer>();
              kaguSup8Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form lowerarm2.png");
              kaguSup8Renderer.sortingLayerName = "Bottom";

              foreach (var c in kaguSup8.GetComponents<Collider2D>())
              {

              }
      kaguSup8.GetComponent<Rigidbody2D>();
              kaguSup8.AddComponent<BoxCollider2D>();
      kaguSup8.transform.SetParent(kaguSup7.gameObject.transform);
      kaguSup8.transform.localPosition = new Vector3(0.5f, -0.5f);
              kaguSup8.transform.localScale = new Vector3(1f, 1f);
              kaguSup8.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;

              kaguSup8.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
              var colSup8 = kaguSup8.AddComponent<NoCollide>();
              colSup8.NoCollideSetA = kaguSup8.GetComponents<Collider2D>();
              colSup8.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

              HingeJoint2D kaguSup8hingeJoint = kaguSup8.GetOrAddComponent<HingeJoint2D>();
              kaguSup8hingeJoint.connectedBody = kaguSup7.gameObject.GetComponent<Rigidbody2D>();
              kaguSup8hingeJoint.anchor = new Vector3(0f, 0f);

              JointAngleLimits2D kaguSup8limits = hingeJoint.limits;
              kaguSup8limits.min = 5;
              kaguSup8limits.max = -5;
              kaguSup8hingeJoint.limits = kaguSup8limits;
       kaguSup8hingeJoint.useLimits = true;



//////////////////////////////////////////////////////////////

     var kagu8 = new GameObject("kagu8");
     kagu8 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
             kagu8.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
             SpriteRenderer kagu8Renderer = kagu8.GetComponent<SpriteRenderer>();
             kagu8Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form body.png");
             kagu8Renderer.sortingLayerName = "Foreground";

             foreach (var c in kagu8.GetComponents<Collider2D>())
             {

             }
     kagu8.GetComponent<Rigidbody2D>();
             kagu8.AddComponent<BoxCollider2D>();
     kagu8.transform.SetParent(kagu7.gameObject.transform);
     kagu8.transform.localPosition = new Vector3(-2f, 0f);
             kagu8.transform.localScale = new Vector3(1f, 1f);
             kagu8.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;



             kagu8.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
             var col2345678 = kagu8.AddComponent<NoCollide>();
             col2345678.NoCollideSetA = kagu8.GetComponents<Collider2D>();
             col2345678.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

             HingeJoint2D kagu8hingeJoint = kagu8.GetOrAddComponent<HingeJoint2D>();
             kagu8hingeJoint.connectedBody = kagu7.gameObject.GetComponent<Rigidbody2D>();
             kagu8hingeJoint.anchor = new Vector3(0f, 0f);

             JointAngleLimits2D kagu8limits = hingeJoint.limits;
             kagu8limits.min = 5;
             kagu8limits.max = -5;
             kagu8hingeJoint.limits = kagu8limits;
      kagu8hingeJoint.useLimits = true;

      var kagu9 = new GameObject("kagu9");
      kagu9 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
              kagu9.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
              SpriteRenderer kagu9Renderer = kagu9.GetComponent<SpriteRenderer>();
              kagu9Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form body.png");
              kagu9Renderer.sortingLayerName = "Foreground";

              foreach (var c in kagu8.GetComponents<Collider2D>())
              {

              }
      kagu9.GetComponent<Rigidbody2D>();
              kagu9.AddComponent<BoxCollider2D>();
      kagu9.transform.SetParent(kagu8.gameObject.transform);
      kagu9.transform.localPosition = new Vector3(-2f, 0f);
              kagu9.transform.localScale = new Vector3(1f, 1f);
              kagu9.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;



              kagu9.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
              var col23456789 = kagu9.AddComponent<NoCollide>();
              col23456789.NoCollideSetA = kagu9.GetComponents<Collider2D>();
              col23456789.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

              HingeJoint2D kagu9hingeJoint = kagu9.GetOrAddComponent<HingeJoint2D>();
              kagu9hingeJoint.connectedBody = kagu8.gameObject.GetComponent<Rigidbody2D>();
              kagu9hingeJoint.anchor = new Vector3(0f, 0f);

              JointAngleLimits2D kagu9limits = hingeJoint.limits;
              kagu9limits.min = 5;
              kagu9limits.max = -5;
              kagu9hingeJoint.limits = kagu9limits;
       kagu9hingeJoint.useLimits = true;

       var kagu10 = new GameObject("kagu10");
       kagu10 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
               kagu10.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
               SpriteRenderer kagu10Renderer = kagu10.GetComponent<SpriteRenderer>();
               kagu10Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form body.png");
               kagu10Renderer.sortingLayerName = "Foreground";

               foreach (var c in kagu8.GetComponents<Collider2D>())
               {

               }
       kagu10.GetComponent<Rigidbody2D>();
               kagu10.AddComponent<BoxCollider2D>();
       kagu10.transform.SetParent(kagu9.gameObject.transform);
       kagu10.transform.localPosition = new Vector3(-2f, 0f);
               kagu10.transform.localScale = new Vector3(1f, 1f);
               kagu10.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;

               var componentttt = kagu10.GetComponent<PhysicalBehaviour>();
               var chelovekkkk = ModAPI.FindPhysicalProperties("AndroidArmour");
               chelovekkkk.Sharp = true;
               chelovekkkk.SharpAxes = new[]
               {
                                       new SharpAxis(Vector2.left, -9999f, 0.15f, true, true),
                                   };
               componentttt.Properties = chelovekkkk;
               var componentttt2 = kagu10.GetComponent<PhysicalBehaviour>();
               componentttt2.Properties = chelovekkkk;

               kagu10.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
               var col234567810 = kagu10.AddComponent<NoCollide>();
               col234567810.NoCollideSetA = kagu10.GetComponents<Collider2D>();
               col234567810.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

               HingeJoint2D kagu10hingeJoint = kagu10.GetOrAddComponent<HingeJoint2D>();
               kagu10hingeJoint.connectedBody = kagu9.gameObject.GetComponent<Rigidbody2D>();
               kagu10hingeJoint.anchor = new Vector3(0f, 0f);

               JointAngleLimits2D kagu10limits = hingeJoint.limits;
               kagu10limits.min = 5;
               kagu10limits.max = -5;
               kagu10hingeJoint.limits = kagu10limits;
      kagu10hingeJoint.useLimits = true;

      var kagu11 = new GameObject("kagu11");
      kagu11 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
              kagu11.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
              SpriteRenderer kagu11Renderer = kagu11.GetComponent<SpriteRenderer>();
              kagu11Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form body.png");
              kagu11Renderer.sortingLayerName = "Foreground";

              foreach (var c in kagu8.GetComponents<Collider2D>())
              {

              }
      kagu11.GetComponent<Rigidbody2D>();
              kagu11.AddComponent<BoxCollider2D>();
      kagu11.transform.SetParent(kagu10.gameObject.transform);
      kagu11.transform.localPosition = new Vector3(-2f, 0f);
              kagu11.transform.localScale = new Vector3(1f, 1f);
              kagu11.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;

              var componenttt = kagu11.GetComponent<PhysicalBehaviour>();
              var chelovekkk = ModAPI.FindPhysicalProperties("AndroidArmour");
              chelovekkk.Sharp = true;
              chelovekkk.SharpAxes = new[]
              {
                                      new SharpAxis(Vector2.left, -9999f, 0.15f, true, true),
                                  };
              componenttt.Properties = chelovekkk;
              var componenttt2 = kagu11.GetComponent<PhysicalBehaviour>();
              componenttt2.Properties = chelovekkk;

              kagu11.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
              var col234567811 = kagu11.AddComponent<NoCollide>();
              col234567811.NoCollideSetA = kagu11.GetComponents<Collider2D>();
              col234567811.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

              HingeJoint2D kagu11hingeJoint = kagu11.GetOrAddComponent<HingeJoint2D>();
              kagu11hingeJoint.connectedBody = kagu10.gameObject.GetComponent<Rigidbody2D>();
              kagu11hingeJoint.anchor = new Vector3(0f, 0f);

              JointAngleLimits2D kagu11limits = hingeJoint.limits;
              kagu11limits.min = 5;
              kagu11limits.max = -5;
              kagu11hingeJoint.limits = kagu11limits;
     kagu11hingeJoint.useLimits = true;

     var kagu12 = new GameObject("kagu12");
     kagu12 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
             kagu12.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
             SpriteRenderer kagu12Renderer = kagu12.GetComponent<SpriteRenderer>();
             kagu12Renderer.sprite = ModAPI.LoadSprite("image/Kaido dragon form tail.png");
             kagu12Renderer.sortingLayerName = "Bottom";

             foreach (var c in kagu8.GetComponents<Collider2D>())
             {

             }
     kagu12.GetComponent<Rigidbody2D>();
             kagu12.AddComponent<BoxCollider2D>();
     kagu12.transform.SetParent(kagu11.gameObject.transform);
     kagu12.transform.localPosition = new Vector3(-2f, 0f);
             kagu12.transform.localScale = new Vector3(1f, 1f);
             kagu12.gameObject.GetComponent<PhysicalBehaviour>().rigidbody.gravityScale = 0f;

             var componentt = kagu12.GetComponent<PhysicalBehaviour>();
             var chelovekk = ModAPI.FindPhysicalProperties("AndroidArmour");
             chelovekk.Sharp = true;
             chelovekk.SharpAxes = new[]
             {
                                     new SharpAxis(Vector2.left, -9999f, 0.15f, true, true),
                                 };
             componentt.Properties = chelovekk;
             var componentt2 = kagu12.GetComponent<PhysicalBehaviour>();
             componentt2.Properties = chelovekk;

             kagu12.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
             var co1212 = kagu12.AddComponent<NoCollide>();
             co1212.NoCollideSetA = kagu12.GetComponents<Collider2D>();
             co1212.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

             HingeJoint2D kagu12hingeJoint = kagu12.GetOrAddComponent<HingeJoint2D>();
             kagu12hingeJoint.connectedBody = kagu10.gameObject.GetComponent<Rigidbody2D>();
             kagu12hingeJoint.anchor = new Vector3(0f, 0f);

             JointAngleLimits2D kagu12limits = hingeJoint.limits;
             kagu12limits.min = 5;
             kagu12limits.max = -5;
             kagu12hingeJoint.limits = kagu12limits;
     kagu12hingeJoint.useLimits = true;


        }
    }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Gol D. Roger",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Gol D. Roger,  was a legendary pirate who, as captain of the Roger Pirates,He is also known as the pirate king." + "\n <color=red>King of the pirates ",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/goldrogerthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Gol D. Roger.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.3f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);

   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   head.gameObject.AddComponent<hao>();
   Lower.gameObject.AddComponent<kenbun>();
   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();


   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
      body.BaseStrength *= 0.1f;
      body.Health *= 11000f;
      body.BreakingThreshold *= 1f;
      body.IsAndroid = true;
      body.transform.root.localScale *= 1.02f;
      body.gameObject.AddComponent<strongrege>();
      UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
      useEventTrigger0.Event = new UnityEvent();
      useEventTrigger0.Event.AddListener(delegate ()
       {
         ModAPI.CreateParticleEffect("Vapor", head.transform.position);
        Audio2.Play();
      });
    UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
    useEventTrigger.Event = new UnityEvent();
    useEventTrigger.Event.AddListener(delegate ()
     {
      body.ImmuneToDamage = true;
      arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
      arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
      arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
      arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
      Audio.Play();
    });

    UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
    useEventTrigger1.Event = new UnityEvent();
    useEventTrigger1.Event.AddListener(delegate ()
     {
       body.ImmuneToDamage = false;
       arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
       arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
       arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
       arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
       Audio.Play();
    });

    UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
    useEventTrigger2.Event = new UnityEvent();
    useEventTrigger2.Event.AddListener(delegate ()
     {
       Audio3.Play();
    });


      var ornamentobject = new GameObject("rogerhair.png");
      ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
      ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
      ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
      ornamentobject.transform.localScale = new Vector3(1f, 1f);
      var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
      ornamentsprite.sprite = ModAPI.LoadSprite("image/rogerhair.png",2.5f);
      ornamentsprite.sortingLayerName = "Middle";

    //cape3
     var backpack = new GameObject("cape3");
     backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
     backpack.transform.localPosition = new Vector3(0, 0f);
     backpack.transform.localScale = new Vector3(1f, 1f);
     var backpackSprite = backpack.AddComponent<SpriteRenderer>();
     backpackSprite.sprite = ModAPI.LoadSprite("image/cape3.png");
     backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
     backpack.AddComponent<UseEventTrigger>().Action = () => {
     backpackSprite.sprite = ModAPI.LoadSprite("none.png");

                                                             };

    //GSword
      var ca = new GameObject("GSword");
      ca.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
      ca.transform.localPosition = new Vector3(0, 0f);
      ca.transform.localScale = new Vector3(1f, 1f);
      var caSprite = ca.AddComponent<SpriteRenderer>();
      caSprite.sprite = ModAPI.LoadSprite("image/GSword.png");
      ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
      ca.AddComponent<UseEventTrigger>().Action = () => {
      caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                         };

      person.SetBruiseColor(000, 000, 000);
      person.SetSecondBruiseColor(000, 000, 000);
      person.SetThirdBruiseColor(000, 000, 000);
      person.SetBloodColour(000, 000, 000);
      person.SetRottenColour(000, 000, 000);


          }
       }
    }
 );

 ModAPI.Register(
     new Modification()
         {
    OriginalItem = ModAPI.FindSpawnable("Human"),
    NameOverride = "Silvers Rayleigh",
    NameToOrderByOverride = "Z1",
    DescriptionOverride = "Silvers Rayleigh, also known as the Dark King is an extremely powerful and famous retired pirate who formerly served as the first mate of the legendary Roger Pirates.",
    CategoryOverride = ModAPI.FindCategory("One Piece pack"),
    ThumbnailOverride = ModAPI.LoadSprite("image/Silvers Rayleighthumbnail.png"),
    AfterSpawn = (Instance) =>
    {

    var skin = ModAPI.LoadTexture("image/Silvers Rayleigh.png");
    var flesh = ModAPI.LoadTexture("Flesh.png");
    var bone = ModAPI.LoadTexture("Bone.png");


    var person = Instance.GetComponent<PersonBehaviour>();

    var head = Instance.transform.Find("Head");
    var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
    var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
    var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
    var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
    var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
    var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
    var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
    var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
    var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
    var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
    var upper = Instance.transform.Find("Body").Find("UpperBody");
    var middle = Instance.transform.Find("Body").Find("MiddleBody");
    var Lower = Instance.transform.Find("Body").Find("LowerBody");

    upper.transform.localScale = new Vector3(1.3f, 1.2f);
    middle.transform.localScale = new Vector3(1.1f, 1.2f);
    head.transform.localScale = new Vector3(0.7f, 0.7f);
    arm3.transform.localScale = new Vector3(1.18f, 1.2f);
    arm4.transform.localScale = new Vector3(1.18f, 1.2f);
    arm1.transform.localScale = new Vector3(1.18f, 1.2f);
    arm2.transform.localScale = new Vector3(1.18f, 1.2f);
    leg3.transform.localScale = new Vector3(1.19f, 1.2f);
    leg4.transform.localScale = new Vector3(1.19f, 1.2f);
    leg1.transform.localScale = new Vector3(1.19f, 1.2f);
    leg2.transform.localScale = new Vector3(1.19f, 1.2f);
    foot1.transform.localScale = new Vector3(1.19f, 1.2f);
    foot2.transform.localScale = new Vector3(1.19f, 1.2f);

    head.transform.localPosition = new Vector3(0.01f, 0.700f);
    arm3.transform.localPosition = new Vector3(0f, -0.15f);
    arm4.transform.localPosition = new Vector3(0f, -0.15f);
    arm1.transform.localPosition = new Vector3(0f, -0.60f);
    arm2.transform.localPosition = new Vector3(0f, -0.60f);
    leg3.transform.localPosition = new Vector3(0f, -0.46f);
    leg4.transform.localPosition = new Vector3(0f, -0.46f);
    leg1.transform.localPosition = new Vector3(0f, -0.96f);
    leg2.transform.localPosition = new Vector3(0f, -0.96f);
    foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
    foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
    AudioSource Audio = Instance.AddComponent<AudioSource>();
    Audio.maxDistance = 10;
    Audio.loop = false;
    Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

    AudioSource Audio2 = Instance.AddComponent<AudioSource>();
    Audio2.maxDistance = 10;
    Audio2.loop = false;
    Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

    AudioSource Audio3 = Instance.AddComponent<AudioSource>();
    Audio3.maxDistance = 10;
    Audio3.loop = false;
    Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

    head.gameObject.AddComponent<hao>();
    Lower.gameObject.AddComponent<kenbun>();
    arm1.gameObject.AddComponent<Busoshoku>();
    arm2.gameObject.AddComponent<Busoshoku>();




    person.SetBodyTextures(skin, flesh, bone, 1);
    foreach (var body in person.Limbs)
     {
       body.BaseStrength *= 0.1f;
       body.Health *= 11000f;
       body.BreakingThreshold *= 1f;
       body.IsAndroid = true;
       body.transform.root.localScale *= 1.01f;
       body.gameObject.AddComponent<strongrege>();
       UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger0.Event = new UnityEvent();
       useEventTrigger0.Event.AddListener(delegate ()
        {
          ModAPI.CreateParticleEffect("Vapor", head.transform.position);
         Audio2.Play();
       });
       UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger.Event = new UnityEvent();
       useEventTrigger.Event.AddListener(delegate ()
        {
         body.ImmuneToDamage = true;
         arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
         arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
         Audio.Play();
       });

       UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger1.Event = new UnityEvent();
       useEventTrigger1.Event.AddListener(delegate ()
        {
          body.ImmuneToDamage = false;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          Audio.Play();
       });

       UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger2.Event = new UnityEvent();
       useEventTrigger2.Event.AddListener(delegate ()
        {
          Audio3.Play();
       });

       var ornamentobject = new GameObject("Rayleighhair.png");
       ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
       ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
       ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
       ornamentobject.transform.localScale = new Vector3(1f, 1f);
       var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
       ornamentsprite.sprite = ModAPI.LoadSprite("image/Rayleighhair.png",2f);
       ornamentsprite.sortingLayerName = "Middle";

       var ornamentobject2 = new GameObject("Rayleighhair2.png");
       ornamentobject2.transform.SetParent(Instance.transform.Find("Head"));
       ornamentobject2.transform.localPosition = new Vector3(-0.03f, 0.03f);
       ornamentobject2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
       ornamentobject2.transform.localScale = new Vector3(1f, 1f);
       var ornamentsprite2 = ornamentobject2.AddComponent<SpriteRenderer>();
       ornamentsprite2.sprite = ModAPI.LoadSprite("image/Rayleighhair2.png",2f);
       ornamentsprite2.sortingLayerName = "Middle";

       var ca = new GameObject("Rayleighcape.png");
       ca.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
       ca.transform.localPosition = new Vector3(0, 0f);
       ca.transform.localScale = new Vector3(1f, 1f);
       var caSprite = ca.AddComponent<SpriteRenderer>();
       caSprite.sprite = ModAPI.LoadSprite("image/Rayleighcape.png");
       ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
       ca.AddComponent<UseEventTrigger>().Action = () => {
       caSprite.sprite = ModAPI.LoadSprite("none.png");
       };

       var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
       var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");

       ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
       ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

       person.SetBruiseColor(000, 000, 000);
       person.SetSecondBruiseColor(000, 000, 000);
       person.SetThirdBruiseColor(000, 000, 000);
       person.SetBloodColour(000, 000, 000);
       person.SetRottenColour(000, 000, 000);

           }
        }
     }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Kozuki Oden",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Kozuki Oden was the daimyo of Kuri in Wano Country and the son of the former shogun Kozuki Sukiyaki.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Kozuki Odenthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Kozuki Oden.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.4f, 1.2f);
   middle.transform.localScale = new Vector3(1.3f, 1.2f);
   Lower.transform.localScale = new Vector3(1.2f, 1f);
   arm3.transform.localScale = new Vector3(1.3f, 1.2f);
   arm4.transform.localScale = new Vector3(1.3f, 1.2f);
   arm1.transform.localScale = new Vector3(1.3f, 1.2f);
   arm2.transform.localScale = new Vector3(1.3f, 1.2f);
   leg3.transform.localScale = new Vector3(1.43f, 1.2f);
   leg4.transform.localScale = new Vector3(1.43f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.2f, 1.2f);
   foot2.transform.localScale = new Vector3(1.2f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.02f, 0.700f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);

   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   head.gameObject.AddComponent<hao>();
   Lower.gameObject.AddComponent<kenbun>();
   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();
   leg1.gameObject.AddComponent<Busoshoku>();
   leg2.gameObject.AddComponent<Busoshoku>();


   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.3f;
        body.Health *= 10000f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1.04f;
        body.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
        body.gameObject.AddComponent<strongrege>();
        body.GetComponent<PhysicalBehaviour>().OverrideImpactSounds = new AudioClip[]
      {
                                    ModAPI.LoadSound("Sound/a1.wav"),
                                    ModAPI.LoadSound("Sound/a2.wav"),
                                    ModAPI.LoadSound("Sound/a3.wav"),
                                    ModAPI.LoadSound("Sound/a4.wav"),
                                    ModAPI.LoadSound("Sound/a5.wav"),
                                    ModAPI.LoadSound("Sound/a6.wav"),
                                    ModAPI.LoadSound("Sound/a1.wav"),
                                    ModAPI.LoadSound("Sound/a2.wav"),
                                    ModAPI.LoadSound("Sound/a3.wav"),
                                  };
                                  UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
                                  useEventTrigger0.Event = new UnityEvent();
                                  useEventTrigger0.Event.AddListener(delegate ()
                                   {
                                     ModAPI.CreateParticleEffect("Vapor", head.transform.position);
                                    Audio2.Play();
                                  });

                                  UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
                                  useEventTrigger.Event = new UnityEvent();
                                  useEventTrigger.Event.AddListener(delegate ()
                                   {
                                    arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
                                    arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
                                    Audio.Play();
                                  });

                                  UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
                                  useEventTrigger1.Event = new UnityEvent();
                                  useEventTrigger1.Event.AddListener(delegate ()
                                   {
                                     arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                                     arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                                     Audio.Play();
                                  });

                                  UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
                                  useEventTrigger2.Event = new UnityEvent();
                                  useEventTrigger2.Event.AddListener(delegate ()
                                   {
                                     Audio3.Play();
                                  });

    //kozuki oden hairstyle
      var ca = new GameObject("kozuki oden hairstyle");
      ca.transform.SetParent(Instance.transform.Find("Head"));
      ca.transform.localPosition = new Vector3(0, 0f);
      ca.transform.localScale = new Vector3(1f, 1f);
      var caSprite = ca.AddComponent<SpriteRenderer>();
      caSprite.sprite = ModAPI.LoadSprite("image/kozuki oden hairstyle.png");
      ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
      ca.AddComponent<UseEventTrigger>().Action = () => {
      caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                         };
  //knot
   var backpack = new GameObject("knot");
   backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
   backpack.transform.localPosition = new Vector3(0, 0f);
   backpack.transform.localScale = new Vector3(1f, 1f);
   var backpackSprite = backpack.AddComponent<SpriteRenderer>();
   backpackSprite.sprite = ModAPI.LoadSprite("image/knot.png");
   backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
   backpack.AddComponent<UseEventTrigger>().Action = () => {
   backpackSprite.sprite = ModAPI.LoadSprite("none.png");
                                                            };


  var ornamentobject = new GameObject("Odenswords.png");
  ornamentobject.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
  ornamentobject.transform.localPosition = new Vector3(-0.03f, 0f);
  ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
  ornamentobject.transform.localScale = new Vector3(1f, 1f);
  var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
  ornamentsprite.sprite = ModAPI.LoadSprite("image/Odenswords.png",0.9f);
  ornamentsprite.sortingLayerName = "Middle";


                        }
                    }
                }
);

ModAPI.Register(
  new Modification()
  {
      OriginalItem = ModAPI.FindSpawnable("Human"),
      NameOverride = "Kaido",
      NameToOrderByOverride = "Z1",
      DescriptionOverride = ""+"\n <color=white>Kaido of the Beasts renowned as the worlds Strongest Creature is the Governor General of the Beasts Pirates and one of the Four Emperors ruling over the New World" + "\n <color=purple>Yonkou ",
      CategoryOverride = ModAPI.FindCategory("One Piece pack"),
      ThumbnailOverride = ModAPI.LoadSprite("image/Kaidothumbnail.png"),
      AfterSpawn = (Instance) =>
      {
          var person = Instance.GetComponent<PersonBehaviour>();
          var head = Instance.transform.Find("Head");
          var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
          var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
          var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
          var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
          var leg1 = Instance.transform.Find("FrontLeg").Find("FootFront");
          var leg2 = Instance.transform.Find("BackLeg").Find("Foot");
          var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
          var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
          var upper = Instance.transform.Find("Body").Find("UpperBody");
          var middle = Instance.transform.Find("Body").Find("MiddleBody");
          var Lower = Instance.transform.Find("Body").Find("LowerBody");

          upper.transform.localScale = new Vector3(1.7f, 1.2f);
          middle.transform.localScale = new Vector3(1.6f, 1.2f);
          Lower.transform.localScale = new Vector3(1.5f, 1.2f);
          arm3.transform.localScale = new Vector3(1.9f, 1.4f);
          arm4.transform.localScale = new Vector3(1.9f, 1.4f);
          arm1.transform.localScale = new Vector3(1.9f, 1.4f);
          arm2.transform.localScale = new Vector3(1.9f, 1.4f);
          leg3.transform.localScale = new Vector3(1.3f, 1f);
          leg4.transform.localScale = new Vector3(1.3f, 1f);

          head.transform.localScale = new Vector3(0.7f, 0.7f);

          head.transform.localPosition = new Vector3(0.02f, 0.700f);

          arm3.transform.localPosition = new Vector3(0f, -0.17f);
          arm4.transform.localPosition = new Vector3(0f, -0.17f);
          arm1.transform.localPosition = new Vector3(0f, -0.68f);
          arm2.transform.localPosition = new Vector3(0f, -0.68f);

          AudioSource Audio2 = Instance.AddComponent<AudioSource>();
          Audio2.maxDistance = 10;
          Audio2.loop = false;
          Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

          AudioSource Audio3 = Instance.AddComponent<AudioSource>();
          Audio3.maxDistance = 10;
          Audio3.loop = false;
          Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");


  head.gameObject.AddComponent<hao>();

          foreach (var body in person.Limbs)
          {
              body.PhysicalBehaviour.ReflectsLasers = true;
              body.PhysicalBehaviour.SimulateTemperature = false;
              body.PhysicalBehaviour.Disintegratable = false;
              body.IsAndroid = true;
              body.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
              body.gameObject.AddComponent<undeath>();
              body.BaseStrength *= 1f;
              body.Health *= 500f;
              body.transform.root.localScale *= 1.107f;

              var Hand = new GameObject("Hand");
              Hand.transform.SetParent(Instance.transform.Find("BackArm").Find("UpperArm"));
              Hand.transform.localPosition = new Vector3(0, 0f);
              Hand.transform.localScale = new Vector3(1f, 1f);
              var HandSprite = Hand.AddComponent<SpriteRenderer>();
              HandSprite.sprite = ModAPI.LoadSprite("image/Kaidoarm2.png");
              HandSprite.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";

              var Up = new GameObject("Up");
              Up.transform.SetParent(Instance.transform.Find("BackArm").Find("LowerArm"));
              Up.transform.localPosition = new Vector3(0, 0f);
              Up.transform.localScale = new Vector3(1f, 1f);
              var UpSprite = Up.AddComponent<SpriteRenderer>();
              UpSprite.sprite = ModAPI.LoadSprite("image/Kaidoarm1.png");
              Up.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";

              body.GetComponent<PhysicalBehaviour>().OverrideImpactSounds = new AudioClip[]
            {
                                          ModAPI.LoadSound("Sound/a1.wav"),
                                          ModAPI.LoadSound("Sound/a2.wav"),
                                          ModAPI.LoadSound("Sound/a3.wav"),
                                          ModAPI.LoadSound("Sound/a4.wav"),
                                          ModAPI.LoadSound("Sound/a5.wav"),
                                          ModAPI.LoadSound("Sound/a6.wav"),
                                          ModAPI.LoadSound("Sound/a1.wav"),
                                          ModAPI.LoadSound("Sound/a2.wav"),
                                          ModAPI.LoadSound("Sound/a3.wav"),
            };


            UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
            useEventTrigger0.Event = new UnityEvent();
            useEventTrigger0.Event.AddListener(delegate ()
             {
               ModAPI.CreateParticleEffect("Vapor", head.transform.position);
              Audio2.Play();
            });

            UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
            useEventTrigger2.Event = new UnityEvent();
            useEventTrigger2.Event.AddListener(delegate ()
             {
               Audio3.Play();
            });


            var ornamentobject = new GameObject("Kaidohair.png");
            ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
            ornamentobject.transform.localPosition = new Vector3(0f, 0f);
            ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            ornamentobject.transform.localScale = new Vector3(1f, 1f);
            var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
            ornamentsprite.sprite = ModAPI.LoadSprite("image/Kaidohair.png");
            ornamentsprite.sortingLayerName = "Mid";


            var ornamentobject2 = new GameObject("cape10.png");
            ornamentobject2.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
            ornamentobject2.transform.localPosition = new Vector3(0f, 0f);
            ornamentobject2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            ornamentobject2.transform.localScale = new Vector3(1f, 1f);
            var ornamentsprite2 = ornamentobject2.AddComponent<SpriteRenderer>();
            ornamentsprite2.sprite = ModAPI.LoadSprite("image/cape10.png");
            ornamentsprite2.sortingLayerName = "Bottom";

            var ornamentobject3 = new GameObject("Kaidobeard.png");
            ornamentobject3.transform.SetParent(Instance.transform.Find("Head"));
            ornamentobject3.transform.localPosition = new Vector3(0f, 0f);
            ornamentobject3.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            ornamentobject3.transform.localScale = new Vector3(1f, 1f);
            var ornamentsprite3 = ornamentobject3.AddComponent<SpriteRenderer>();
            ornamentsprite3.sprite = ModAPI.LoadSprite("image/Kaidobeard.png");
            ornamentsprite3.sortingLayerName = "Top";

            var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
            var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");

            ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
            ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

          }
          var skin = ModAPI.LoadTexture("image/Kaido.png");
var flesh = ModAPI.LoadTexture("Flesh.png");
var bone = ModAPI.LoadTexture("Bone.png");
          Instance.GetComponent<PersonBehaviour>().SetBodyTextures(skin, flesh, bone);




      }
  }
);

ModAPI.Register(
  new Modification()
  {
      OriginalItem = ModAPI.FindSpawnable("Human"),
      NameOverride = "Kaido hybrid form",
      NameToOrderByOverride = "Z1",
      DescriptionOverride = ""+"\n <color=white>Kaido hybrid form" + "\n <color=purple>Yonkou ",
      CategoryOverride = ModAPI.FindCategory("One Piece pack"),
      ThumbnailOverride = ModAPI.LoadSprite("image/Kaido hybrid formthumb.png"),
      AfterSpawn = (Instance) =>
      {
          var person = Instance.GetComponent<PersonBehaviour>();
          var head = Instance.transform.Find("Head");
          var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
          var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
          var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
          var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
          var leg1 = Instance.transform.Find("FrontLeg").Find("FootFront");
          var leg2 = Instance.transform.Find("BackLeg").Find("Foot");
          var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
          var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
          var upper = Instance.transform.Find("Body").Find("UpperBody");
          var middle = Instance.transform.Find("Body").Find("MiddleBody");
          var Lower = Instance.transform.Find("Body").Find("LowerBody");

          upper.transform.localScale = new Vector3(1.7f, 1.2f);
          middle.transform.localScale = new Vector3(1.6f, 1.2f);
          Lower.transform.localScale = new Vector3(1.5f, 1.2f);
          arm3.transform.localScale = new Vector3(1.9f, 1.4f);
          arm4.transform.localScale = new Vector3(1.9f, 1.4f);
          arm1.transform.localScale = new Vector3(1.9f, 1.4f);
          arm2.transform.localScale = new Vector3(1.9f, 1.4f);
          leg3.transform.localScale = new Vector3(1.3f, 1f);
          leg4.transform.localScale = new Vector3(1.3f, 1f);
          leg1.transform.localScale = new Vector3(1.3f, 1.3f);
          leg2.transform.localScale = new Vector3(1.3f, 1.3f);

          head.transform.localScale = new Vector3(0.7f, 0.7f);

          head.transform.localPosition = new Vector3(0.02f, 0.700f);

          arm3.transform.localPosition = new Vector3(0f, -0.17f);
          arm4.transform.localPosition = new Vector3(0f, -0.17f);
          arm1.transform.localPosition = new Vector3(0f, -0.68f);
          arm2.transform.localPosition = new Vector3(0f, -0.68f);
          leg1.transform.localPosition = new Vector3(0.0957f, -1.1027f);
          leg2.transform.localPosition = new Vector3(0.0957f, -1.1027f);


          AudioSource Audio2 = Instance.AddComponent<AudioSource>();
          Audio2.maxDistance = 10;
          Audio2.loop = false;
          Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");



  head.gameObject.AddComponent<hao>();
  Lower.gameObject.AddComponent<kenbun>();

          foreach (var body in person.Limbs)
          {
              body.PhysicalBehaviour.ReflectsLasers = true;
              body.PhysicalBehaviour.SimulateTemperature = false;
              body.PhysicalBehaviour.Disintegratable = false;
              body.IsAndroid = true;
              body.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
              body.gameObject.AddComponent<undeath>();
              body.BaseStrength *= 1f;
              body.Health *= 500f;
              body.transform.root.localScale *= 1.107f;
              body.GetComponent<PhysicalBehaviour>().OverrideImpactSounds = new AudioClip[]
            {
                                          ModAPI.LoadSound("Sound/a1.wav"),
                                          ModAPI.LoadSound("Sound/a2.wav"),
                                          ModAPI.LoadSound("Sound/a3.wav"),
                                          ModAPI.LoadSound("Sound/a4.wav"),
                                          ModAPI.LoadSound("Sound/a5.wav"),
                                          ModAPI.LoadSound("Sound/a6.wav"),
                                          ModAPI.LoadSound("Sound/a1.wav"),
                                          ModAPI.LoadSound("Sound/a2.wav"),
                                          ModAPI.LoadSound("Sound/a3.wav"),
            };


            UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
            useEventTrigger0.Event = new UnityEvent();
            useEventTrigger0.Event.AddListener(delegate ()
             {
               ModAPI.CreateParticleEffect("Vapor", head.transform.position);
              Audio2.Play();
            });


            var ornamentobject = new GameObject("Kaidohair2.png");
            ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
            ornamentobject.transform.localPosition = new Vector3(0f, 0f);
            ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            ornamentobject.transform.localScale = new Vector3(1f, 1f);
            var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
            ornamentsprite.sprite = ModAPI.LoadSprite("image/Kaidohair2.png");
            ornamentsprite.sortingLayerName = "Foreground";


            var ornamentobject2 = new GameObject("cape10.png");
            ornamentobject2.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
            ornamentobject2.transform.localPosition = new Vector3(0f, 0f);
            ornamentobject2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            ornamentobject2.transform.localScale = new Vector3(1f, 1f);
            var ornamentsprite2 = ornamentobject2.AddComponent<SpriteRenderer>();
            ornamentsprite2.sprite = ModAPI.LoadSprite("image/cape10.png");
            ornamentsprite2.sortingLayerName = "Middle";

            var ornamentobject3 = new GameObject("Kaidobeard2.png");
            ornamentobject3.transform.SetParent(Instance.transform.Find("Head"));
            ornamentobject3.transform.localPosition = new Vector3(0f, 0f);
            ornamentobject3.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            ornamentobject3.transform.localScale = new Vector3(1f, 1f);
            var ornamentsprite3 = ornamentobject3.AddComponent<SpriteRenderer>();
            ornamentsprite3.sprite = ModAPI.LoadSprite("image/Kaidobeard2.png");
            ornamentsprite3.sortingLayerName = "Top";


            var ornamentobject5 = new GameObject("Kaido hybrid formtail.png");
            ornamentobject5.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
            ornamentobject5.transform.localPosition = new Vector3(0f, 0f);
            ornamentobject5.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            ornamentobject5.transform.localScale = new Vector3(1f, 1f);
            var ornamentsprite5 = ornamentobject5.AddComponent<SpriteRenderer>();
            ornamentsprite5.sprite = ModAPI.LoadSprite("image/Kaido hybrid formtail.png");
            ornamentsprite5.sortingLayerName = "Bottom";

            var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
            var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");

            ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
            ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";


          }
          var skin = ModAPI.LoadTexture("image/Kaido hybrid form.png");
var flesh = ModAPI.LoadTexture("Flesh.png");
var bone = ModAPI.LoadTexture("Bone.png");
          Instance.GetComponent<PersonBehaviour>().SetBodyTextures(skin, flesh, bone);




      }
  }
);

ModAPI.Register(
new Modification()
{
  OriginalItem = ModAPI.FindSpawnable("Human"),
  NameOverride = "Charlotte Linlin",
  NameToOrderByOverride = "Z1",
  DescriptionOverride = ""+"\n <color=white>Charlotte Linlin better known as Big Mom, is the captain of the Big Mom Pirates and one of the Four Emperors ruling over the New World, as the only female member." + "\n <color=purple>Yonkou ",
  CategoryOverride = ModAPI.FindCategory("One Piece pack"),
  ThumbnailOverride = ModAPI.LoadSprite("image/Charlotte Linlinthumbnail.png"),
  AfterSpawn = (Instance) =>
  {
    var person = Instance.GetComponent<PersonBehaviour>();
    var head = Instance.transform.Find("Head");
    var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
    var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
    var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
    var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
    var leg1 = Instance.transform.Find("FrontLeg").Find("FootFront");
    var leg2 = Instance.transform.Find("BackLeg").Find("Foot");
    var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
    var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
    var upper = Instance.transform.Find("Body").Find("UpperBody");
    var middle = Instance.transform.Find("Body").Find("MiddleBody");
    var Lower = Instance.transform.Find("Body").Find("LowerBody");

    upper.transform.localScale = new Vector3(1.5f, 1.2f);
    middle.transform.localScale = new Vector3(1.6f, 1.2f);
    Lower.transform.localScale = new Vector3(1.7f, 1.2f);
    arm3.transform.localScale = new Vector3(1.9f, 1.4f);
    arm4.transform.localScale = new Vector3(1.9f, 1.4f);
    arm1.transform.localScale = new Vector3(1.9f, 1.4f);
    arm2.transform.localScale = new Vector3(1.9f, 1.4f);
    leg3.transform.localScale = new Vector3(1.3f, 1f);
    leg4.transform.localScale = new Vector3(1.3f, 1f);

    head.transform.localScale = new Vector3(0.7f, 0.7f);

    head.transform.localPosition = new Vector3(0.02f, 0.732f);

    arm3.transform.localPosition = new Vector3(0f, -0.17f);
    arm4.transform.localPosition = new Vector3(0f, -0.17f);
    arm1.transform.localPosition = new Vector3(0f, -0.68f);
    arm2.transform.localPosition = new Vector3(0f, -0.68f);

    AudioSource Audio = Instance.AddComponent<AudioSource>();
    Audio.maxDistance = 10;
    Audio.loop = false;
    Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

    AudioSource Audio2 = Instance.AddComponent<AudioSource>();
    Audio2.maxDistance = 10;
    Audio2.loop = false;
    Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

    AudioSource Audio3 = Instance.AddComponent<AudioSource>();
    Audio3.maxDistance = 10;
    Audio3.loop = false;
    Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

    head.gameObject.AddComponent<hao>();
    Lower.gameObject.AddComponent<kenbun>();
    arm1.gameObject.AddComponent<Busoshoku>();
    arm2.gameObject.AddComponent<Busoshoku>();

      foreach (var body in person.Limbs)
      {
        body.PhysicalBehaviour.ReflectsLasers = true;
        body.IsAndroid = true;
        body.BreakingThreshold *= 100f;
        body.BaseStrength *= 0.5f;
        body.Health *= 500f;
        body.Wince(0f);
        body.DoStumble = true;
  			body.DoBalanceJerk = true;
        body.transform.root.localScale *= 1.106f;
        body.gameObject.AddComponent<strongrege>();

        UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger0.Event = new UnityEvent();
        useEventTrigger0.Event.AddListener(delegate ()
         {
           ModAPI.CreateParticleEffect("Vapor", head.transform.position);
          Audio2.Play();
        });
        UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });


        UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger2.Event = new UnityEvent();
        useEventTrigger2.Event.AddListener(delegate ()
         {
           Audio3.Play();
        });

        var ca = new GameObject("linlinhat2");
        ca.transform.SetParent(Instance.transform.Find("Head"));
        ca.transform.localPosition = new Vector3(0, 0f);
        ca.transform.localScale = new Vector3(1f, 1f);
        var caSprite = ca.AddComponent<SpriteRenderer>();
        caSprite.sprite = ModAPI.LoadSprite("image/linlinhat2.png");
        ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        ca.AddComponent<UseEventTrigger>().Action = () => {
        caSprite.sprite = ModAPI.LoadSprite("none.png");
        };

        var ca2 = new GameObject("linlinhat1.png");
        ca2.transform.SetParent(Instance.transform.Find("Head"));
        ca2.transform.localPosition = new Vector3(0, 0f);
        ca2.transform.localScale = new Vector3(1f, 1f);
        var ca2Sprite = ca2.AddComponent<SpriteRenderer>();
        ca2Sprite.sprite = ModAPI.LoadSprite("image/linlinhat1.png");
        ca2.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
        ca2.AddComponent<UseEventTrigger>().Action = () => {
        ca2Sprite.sprite = ModAPI.LoadSprite("none.png");
        };

        var ca3 = new GameObject("linlincape");
        ca3.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
        ca3.transform.localPosition = new Vector3(0, 0f);
        ca3.transform.localScale = new Vector3(1f, 1f);
        var ca3Sprite = ca3.AddComponent<SpriteRenderer>();
        ca3Sprite.sprite = ModAPI.LoadSprite("image/linlincape.png");
        ca3.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        ca3.AddComponent<UseEventTrigger>().Action = () => {
        ca3Sprite.sprite = ModAPI.LoadSprite("none.png");
        };

        var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
        var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");

        ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

       }
      var skin = ModAPI.LoadTexture("image/Charlotte Linlin.png");
var flesh = ModAPI.LoadTexture("Flesh.png");
var bone = ModAPI.LoadTexture("Bone.png");
      Instance.GetComponent<PersonBehaviour>().SetBodyTextures(skin, flesh, bone);

      Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/linlinbreast.png");
      Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().material.SetTexture("_FleshTex", ModAPI.LoadTexture("image/Fleshbreast.png"));
      Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().material.SetTexture("_BoneTex", ModAPI.LoadTexture("image/Bonebreast.png"));


  }
}
);

ModAPI.Register(
new Modification()
{
    OriginalItem = ModAPI.FindSpawnable("Human"),
    NameOverride = "Edward Newgate",
    NameToOrderByOverride = "Z1",
    DescriptionOverride = ""+"\n <color=white>Edward Newgate more commonly known as Whitebeard was the captain of the Whitebeard Pirates" + "\n <color=purple>Yonkou ",
    CategoryOverride = ModAPI.FindCategory("One Piece pack"),
    ThumbnailOverride = ModAPI.LoadSprite("image/whitebeardthumnail.png"),
    AfterSpawn = (Instance) =>
    {
        var person = Instance.GetComponent<PersonBehaviour>();

        var head = Instance.transform.Find("Head");
        var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
        var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
        var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
        var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
        var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
        var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
        var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
        var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
        var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
        var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
        var upper = Instance.transform.Find("Body").Find("UpperBody");
        var middle = Instance.transform.Find("Body").Find("MiddleBody");
        var Lower = Instance.transform.Find("Body").Find("LowerBody");

        upper.transform.localScale = new Vector3(1.4f, 1.2f);
        middle.transform.localScale = new Vector3(1.3f, 1.2f);
        Lower.transform.localScale = new Vector3(1.2f, 1f);
        arm3.transform.localScale = new Vector3(1.3f, 1.2f);
        arm4.transform.localScale = new Vector3(1.3f, 1.2f);
        arm1.transform.localScale = new Vector3(1.3f, 1.2f);
        arm2.transform.localScale = new Vector3(1.3f, 1.2f);
        leg3.transform.localScale = new Vector3(1.43f, 1.2f);
        leg4.transform.localScale = new Vector3(1.43f, 1.2f);
        leg1.transform.localScale = new Vector3(1.19f, 1.2f);
        leg2.transform.localScale = new Vector3(1.19f, 1.2f);
        foot1.transform.localScale = new Vector3(1.19f, 1.2f);
        foot2.transform.localScale = new Vector3(1.19f, 1.2f);
        head.transform.localScale = new Vector3(0.7f, 0.7f);

        head.transform.localPosition = new Vector3(0.02f, 0.700f);
        leg3.transform.localPosition = new Vector3(0f, -0.46f);
        leg4.transform.localPosition = new Vector3(0f, -0.46f);
        leg1.transform.localPosition = new Vector3(0f, -0.96f);
        leg2.transform.localPosition = new Vector3(0f, -0.96f);
        foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
        foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);

        arm3.transform.localPosition = new Vector3(0f, -0.15f);
        arm4.transform.localPosition = new Vector3(0f, -0.15f);
        arm1.transform.localPosition = new Vector3(0f, -0.60f);
        arm2.transform.localPosition = new Vector3(0f, -0.60f);
        AudioSource Audio = Instance.AddComponent<AudioSource>();
        Audio.maxDistance = 10;
        Audio.loop = false;
        Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");


        AudioSource Audio2 = Instance.AddComponent<AudioSource>();
        Audio2.maxDistance = 10;
        Audio2.loop = false;
        Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

        AudioSource Audio3 = Instance.AddComponent<AudioSource>();
        Audio3.maxDistance = 10;
        Audio3.loop = false;
        Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");


        AudioClip Repulsor = ModAPI.LoadSound("Sound/guragurarug.mp3");
        AudioClip beam2 = ModAPI.LoadSound("Sound/guragurarug.mp3");


        head.gameObject.AddComponent<hao>();
        Lower.gameObject.AddComponent<kenbun>();
        arm1.gameObject.AddComponent<ryuo>();
        arm2.gameObject.AddComponent<ryuo>();
        arm1.gameObject.AddComponent<guraguranomi>();
        arm2.gameObject.AddComponent<guraguranomi>();


        foreach (var Limbs in person.Limbs)
        {;

            if (Limbs.GetComponent<GripBehaviour>())
            {
                Limbs.gameObject.AddComponent<UseEventTrigger>().Action = () =>
                {


                    AudioSource audio = Limbs.gameObject.AddComponent<AudioSource>();
                    audio.spatialBlend = 1;
                    audio.PlayOneShot(Repulsor);
                };
            }
        }head.gameObject.AddComponent<hao>();


        foreach (var body in person.Limbs)
        {

            body.PhysicalBehaviour.ReflectsLasers = true;
            body.PhysicalBehaviour.SimulateTemperature = false;
            body.PhysicalBehaviour.Disintegratable = false;
            body.PhysicalBehaviour.Deletable = false;
            body.IsAndroid = true;
            body.Health *= 666f;
            body.BaseStrength *= 1f;
            body.Health *= 500f;
            body.Wince(0f);
            body.DoStumble = true;
      			body.DoBalanceJerk = true;
            body.BreakingThreshold *= 100f;
            body.transform.root.localScale *= 1.09f;
            body.gameObject.AddComponent<strongrege>();
            UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
            useEventTrigger0.Event = new UnityEvent();
            useEventTrigger0.Event.AddListener(delegate ()
             {
               ModAPI.CreateParticleEffect("Vapor", head.transform.position);
              Audio2.Play();
            });

            UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
            useEventTrigger.Event = new UnityEvent();
            useEventTrigger.Event.AddListener(delegate ()
             {
              body.ImmuneToDamage = true;
              arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
              arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
              arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
              arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
              Audio.Play();
            });


            UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
            useEventTrigger1.Event = new UnityEvent();
            useEventTrigger1.Event.AddListener(delegate ()
             {
               body.ImmuneToDamage = false;
               arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
               arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
               arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
               arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
               Audio.Play();
            });


            UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
            useEventTrigger2.Event = new UnityEvent();
            useEventTrigger2.Event.AddListener(delegate ()
             {
               Audio3.Play();
            });

            var ca = new GameObject("edwardhat2");
            ca.transform.SetParent(Instance.transform.Find("Head"));
            ca.transform.localPosition = new Vector3(0, 0f);
            ca.transform.localScale = new Vector3(1f, 1f);
            var caSprite = ca.AddComponent<SpriteRenderer>();
            caSprite.sprite = ModAPI.LoadSprite("image/edwardhat2.png");
            ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
            ca.AddComponent<UseEventTrigger>().Action = () => {
            caSprite.sprite = ModAPI.LoadSprite("none.png");
            };

            var ca2 = new GameObject("edwardhat1.png");
            ca2.transform.SetParent(Instance.transform.Find("Head"));
            ca2.transform.localPosition = new Vector3(0, 0f);
            ca2.transform.localScale = new Vector3(1f, 1f);
            var ca2Sprite = ca2.AddComponent<SpriteRenderer>();
            ca2Sprite.sprite = ModAPI.LoadSprite("image/edwardhat1.png");
            ca2.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
            ca2.AddComponent<UseEventTrigger>().Action = () => {
            ca2Sprite.sprite = ModAPI.LoadSprite("none.png");
            };


        //cape2
         var backpack = new GameObject("cape2");
         backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
         backpack.transform.localPosition = new Vector3(0, 0f);
         backpack.transform.localScale = new Vector3(1f, 1f);
         var backpackSprite = backpack.AddComponent<SpriteRenderer>();
         backpackSprite.sprite = ModAPI.LoadSprite("image/cape2.png");
         backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
         backpack.AddComponent<UseEventTrigger>().Action = () => {
         backpackSprite.sprite = ModAPI.LoadSprite("none.png");

        };
        }
        var skin = ModAPI.LoadTexture("image/whitebeard.png");
var flesh = ModAPI.LoadTexture("Flesh.png");
var bone = ModAPI.LoadTexture("Bone.png");
        Instance.GetComponent<PersonBehaviour>().SetBodyTextures(skin, flesh, bone);




    }
}
);

ModAPI.Register(
      new Modification()
          {
     OriginalItem = ModAPI.FindSpawnable("Human"),
     NameOverride = "Marshall D. Teach",
     NameToOrderByOverride = "Z1",
     DescriptionOverride = ""+"\n <color=white>Marshall D. Teach most commonly referred to by his epithet Blackbeard is the captain-turned-admiral of the Blackbeard Pirates and currently one of the Four Emperors." + "\n <color=purple>Yonkou ",
     CategoryOverride = ModAPI.FindCategory("One Piece pack"),
     ThumbnailOverride = ModAPI.LoadSprite("image/Marshall D. Teachthumnail.png"),
     AfterSpawn = (Instance) =>
     {

     var skin = ModAPI.LoadTexture("image/Marshall D. Teach.png");
     var flesh = ModAPI.LoadTexture("Flesh.png");
     var bone = ModAPI.LoadTexture("Bone.png");

     var person = Instance.GetComponent<PersonBehaviour>();

     var head = Instance.transform.Find("Head");
     var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
     var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
     var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
     var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
     var leg1 = Instance.transform.Find("FrontLeg").Find("FootFront");
     var leg2 = Instance.transform.Find("BackLeg").Find("Foot");
     var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
     var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
     var upper = Instance.transform.Find("Body").Find("UpperBody");
     var middle = Instance.transform.Find("Body").Find("MiddleBody");
     var Lower = Instance.transform.Find("Body").Find("LowerBody");

     upper.transform.localScale = new Vector3(1.8f, 1.2f);
     middle.transform.localScale = new Vector3(1.8f, 1.2f);
     Lower.transform.localScale = new Vector3(1.8f, 1f);
     arm3.transform.localScale = new Vector3(1.3f, 1.2f);
     arm4.transform.localScale = new Vector3(1.3f, 1.2f);
     arm1.transform.localScale = new Vector3(1.3f, 1.2f);
     arm2.transform.localScale = new Vector3(1.3f, 1.2f);
     leg3.transform.localScale = new Vector3(1.2f, 1f);
     leg4.transform.localScale = new Vector3(1.2f, 1f);
     head.transform.localScale = new Vector3(0.7f, 0.7f);

     head.transform.localPosition = new Vector3(0.03f, 0.700f);

     arm3.transform.localPosition = new Vector3(0f, -0.15f);
     arm4.transform.localPosition = new Vector3(0f, -0.15f);
     arm1.transform.localPosition = new Vector3(0f, -0.60f);
     arm2.transform.localPosition = new Vector3(0f, -0.60f);

     AudioSource Audio3 = Instance.AddComponent<AudioSource>();
     Audio3.maxDistance = 10;
     Audio3.loop = false;
     Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

Lower.gameObject.AddComponent<kenbun>();
     arm2.gameObject.AddComponent<guraguranomi>();
     arm1.gameObject.AddComponent<yaminomi>();



     person.SetBodyTextures(skin, flesh, bone, 1);
     foreach (var body in person.Limbs)
      {
         body.BaseStrength *= 0.3f;
         body.Health *= 1000000f;
         body.BreakingThreshold *= 1f;
         body.IsAndroid = true;
         body.transform.root.localScale *= 1.04f;
         body.gameObject.AddComponent<strongrege>();



         UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
         useEventTrigger2.Event = new UnityEvent();
         useEventTrigger2.Event.AddListener(delegate ()
          {
            Audio3.Play();
         });

         var ca = new GameObject("Teachhat1");
         ca.transform.SetParent(Instance.transform.Find("Head"));
         ca.transform.localPosition = new Vector3(0, 0f);
         ca.transform.localScale = new Vector3(1f, 1f);
         var caSprite = ca.AddComponent<SpriteRenderer>();
         caSprite.sprite = ModAPI.LoadSprite("image/Teachhat1.png");
         ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
         ca.AddComponent<UseEventTrigger>().Action = () => {
         caSprite.sprite = ModAPI.LoadSprite("none.png");
         };

         var ca2 = new GameObject("Teachhair1.png");
         ca2.transform.SetParent(Instance.transform.Find("Head"));
         ca2.transform.localPosition = new Vector3(0, 0f);
         ca2.transform.localScale = new Vector3(1f, 1f);
         var ca2Sprite = ca2.AddComponent<SpriteRenderer>();
         ca2Sprite.sprite = ModAPI.LoadSprite("image/Teachhair1.png");
         ca2.GetComponent<SpriteRenderer>().sortingLayerName = "Backgruond";
         ca2.AddComponent<UseEventTrigger>().Action = () => {
         ca2Sprite.sprite = ModAPI.LoadSprite("none.png");
         };


      //cape16
       var backpack = new GameObject("cape16");
       backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
       backpack.transform.localPosition = new Vector3(0, 0f);
       backpack.transform.localScale = new Vector3(1f, 1f);
       var backpackSprite = backpack.AddComponent<SpriteRenderer>();
       backpackSprite.sprite = ModAPI.LoadSprite("image/cape16.png");
       backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
       backpack.AddComponent<UseEventTrigger>().Action = () => {
       backpackSprite.sprite = ModAPI.LoadSprite("none.png");

                                                                };
      var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
      var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");

      ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

       person.SetBruiseColor(000, 000, 000);
       person.SetSecondBruiseColor(051, 051, 051);
       person.SetThirdBruiseColor(051, 051, 051);
       person.SetBloodColour(000, 000, 000);
       person.SetRottenColour(000, 000, 000);


             }
          }
       }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Shanks",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = ""+"\n <color=white>Red-Haired Shanks, commonly known as just Red Hair, is the chief of the Red Hair Pirates and one of the Four Emperors that rule over the New World." + "\n <color=purple>Yonkou ",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Shanksthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Shanks.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");

   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.3f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   head.gameObject.AddComponent<hao>();
   Lower.gameObject.AddComponent<kenbun>();
   arm1.gameObject.AddComponent<Busoshoku>();


   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.1f;
        body.Health *= 10000000f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1.01f;
        body.PhysicalBehaviour.BurningProgressionMultiplier = -1000000;
        body.gameObject.AddComponent<strongrege>();
        UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger0.Event = new UnityEvent();
        useEventTrigger0.Event.AddListener(delegate ()
         {
           ModAPI.CreateParticleEffect("Vapor", head.transform.position);
          Audio2.Play();
        });
        UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });


        UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger2.Event = new UnityEvent();
        useEventTrigger2.Event.AddListener(delegate ()
         {
           Audio3.Play();
        });

        var ornamentobject = new GameObject("shankshair.png");
       ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
       ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
       ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
       ornamentobject.transform.localScale = new Vector3(1f, 1f);
       var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
       ornamentsprite.sprite = ModAPI.LoadSprite("image/shankshair.png",3f);
       ornamentsprite.sortingLayerName = "Middle";

       var ornamentobject2 = new GameObject("shankshair2.png");
       ornamentobject2.transform.SetParent(Instance.transform.Find("Head"));
       ornamentobject2.transform.localPosition = new Vector3(-0.03f, 0.03f);
       ornamentobject2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
       ornamentobject2.transform.localScale = new Vector3(1f, 1f);
       var ornamentsprite2 = ornamentobject2.AddComponent<SpriteRenderer>();
       ornamentsprite2.sprite = ModAPI.LoadSprite("image/shankshair2.png",3f);
       ornamentsprite2.sortingLayerName = "Top";

        //cape6
         var backpack = new GameObject("cape6");
         backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
         backpack.transform.localPosition = new Vector3(0, 0f);
         backpack.transform.localScale = new Vector3(1f, 1f);
         var backpackSprite = backpack.AddComponent<SpriteRenderer>();
         backpackSprite.sprite = ModAPI.LoadSprite("image/cape6.png");
         backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
         backpack.AddComponent<UseEventTrigger>().Action = () => {
         backpackSprite.sprite = ModAPI.LoadSprite("none.png");

                                                                 };

        //Ssword
          var ca = new GameObject("Ssword");
          ca.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
          ca.transform.localPosition = new Vector3(0, 0f);
          ca.transform.localScale = new Vector3(1f, 1f);
          var caSprite = ca.AddComponent<SpriteRenderer>();
          caSprite.sprite = ModAPI.LoadSprite("image/Ssword.png");
          ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
          ca.AddComponent<UseEventTrigger>().Action = () => {
          caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                             };
          Instance.transform.Find("BackArm").Find("LowerArm").gameObject.GetComponent<PhysicalBehaviour>().Disintegrate();
          Instance.transform.Find("BackArm").Find("UpperArm").gameObject.GetComponent<PhysicalBehaviour>().Disintegrate();

          person.SetBruiseColor(000, 000, 000);
          person.SetSecondBruiseColor(000, 000, 000);
          person.SetThirdBruiseColor(000, 000, 000);
          person.SetBloodColour(000, 000, 000);
          person.SetRottenColour(000, 000, 000);

                        }
                    }
                }
  );
  ModAPI.Register(
      new Modification()
          {
     OriginalItem = ModAPI.FindSpawnable("Human"),
     NameOverride = "Dracule Mihawk",
     NameToOrderByOverride = "Z1",
     DescriptionOverride = "Dracule Hawk Eyes Mihawk is a world-famous pirate who holds the title of Strongest Swordsman in the World.",
     CategoryOverride = ModAPI.FindCategory("One Piece pack"),
     ThumbnailOverride = ModAPI.LoadSprite("image/Dracule Mihawkthumbnail.png"),
     AfterSpawn = (Instance) =>
     {

     var skin = ModAPI.LoadTexture("image/Dracule Mihawk.png");
     var flesh = ModAPI.LoadTexture("Flesh.png");
     var bone = ModAPI.LoadTexture("Bone.png");


     var person = Instance.GetComponent<PersonBehaviour>();

     var head = Instance.transform.Find("Head");
     var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
     var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
     var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
     var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
     var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
     var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
     var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
     var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
     var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
     var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
     var upper = Instance.transform.Find("Body").Find("UpperBody");
     var middle = Instance.transform.Find("Body").Find("MiddleBody");
     var Lower = Instance.transform.Find("Body").Find("LowerBody");

     upper.transform.localScale = new Vector3(1.3f, 1.2f);
     middle.transform.localScale = new Vector3(1.1f, 1.2f);
     head.transform.localScale = new Vector3(0.7f, 0.7f);
     arm3.transform.localScale = new Vector3(1.18f, 1.2f);
     arm4.transform.localScale = new Vector3(1.18f, 1.2f);
     arm1.transform.localScale = new Vector3(1.18f, 1.2f);
     arm2.transform.localScale = new Vector3(1.18f, 1.2f);
     leg3.transform.localScale = new Vector3(1.19f, 1.2f);
     leg4.transform.localScale = new Vector3(1.19f, 1.2f);
     leg1.transform.localScale = new Vector3(1.19f, 1.2f);
     leg2.transform.localScale = new Vector3(1.19f, 1.2f);
     foot1.transform.localScale = new Vector3(1.19f, 1.2f);
     foot2.transform.localScale = new Vector3(1.19f, 1.2f);

     head.transform.localPosition = new Vector3(0.01f, 0.700f);
     arm3.transform.localPosition = new Vector3(0f, -0.15f);
     arm4.transform.localPosition = new Vector3(0f, -0.15f);
     arm1.transform.localPosition = new Vector3(0f, -0.60f);
     arm2.transform.localPosition = new Vector3(0f, -0.60f);
     leg3.transform.localPosition = new Vector3(0f, -0.46f);
     leg4.transform.localPosition = new Vector3(0f, -0.46f);
     leg1.transform.localPosition = new Vector3(0f, -0.96f);
     leg2.transform.localPosition = new Vector3(0f, -0.96f);
     foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
     foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
     AudioSource Audio = Instance.AddComponent<AudioSource>();
     Audio.maxDistance = 10;
     Audio.loop = false;
     Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

     AudioSource Audio3 = Instance.AddComponent<AudioSource>();
     Audio3.maxDistance = 10;
     Audio3.loop = false;
     Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

Lower.gameObject.AddComponent<kenbun>();
     arm1.gameObject.AddComponent<Busoshoku>();
     arm2.gameObject.AddComponent<Busoshoku>();
     leg1.gameObject.AddComponent<Busoshoku>();
     leg2.gameObject.AddComponent<Busoshoku>();

     person.SetBodyTextures(skin, flesh, bone, 1);
     foreach (var body in person.Limbs)
      {
          body.BaseStrength *= 0.1f;
          body.Health *= 10000000f;
          body.BreakingThreshold *= 1f;
          body.IsAndroid = true;
          body.transform.root.localScale *= 1.01f;
          body.PhysicalBehaviour.BurningProgressionMultiplier = -1000000;
          body.gameObject.AddComponent<strongrege>();
          UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
          useEventTrigger.Event = new UnityEvent();
          useEventTrigger.Event.AddListener(delegate ()
           {
            body.ImmuneToDamage = true;
            arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
            arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
            arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
            arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
            Audio.Play();
          });

          UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
          useEventTrigger1.Event = new UnityEvent();
          useEventTrigger1.Event.AddListener(delegate ()
           {
             body.ImmuneToDamage = false;
             arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
             arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
             arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
             arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
             Audio.Play();
          });

          UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
          useEventTrigger2.Event = new UnityEvent();
          useEventTrigger2.Event.AddListener(delegate ()
           {
             Audio3.Play();
          });



      //Mhat
        var ca = new GameObject("Mhat");
        ca.transform.SetParent(Instance.transform.Find("Head"));
        ca.transform.localPosition = new Vector3(0, 0f);
        ca.transform.localScale = new Vector3(1f, 1f);
        var caSprite = ca.AddComponent<SpriteRenderer>();
        caSprite.sprite = ModAPI.LoadSprite("image/Mhat.png");
        ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        ca.AddComponent<UseEventTrigger>().Action = () => {
        caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                           };

        var ornamentobject = new GameObject("Mihawkhair.png");
        ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
        ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
        ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        ornamentobject.transform.localScale = new Vector3(1f, 1f);
        var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
        ornamentsprite.sprite = ModAPI.LoadSprite("image/Mihawkhair.png",2f);
        ornamentsprite.sortingLayerName = "Middle";

      //cape7
       var backpack = new GameObject("cape7");
       backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
       backpack.transform.localPosition = new Vector3(0, 0f);
       backpack.transform.localScale = new Vector3(1f, 1f);
       var backpackSprite = backpack.AddComponent<SpriteRenderer>();
       backpackSprite.sprite = ModAPI.LoadSprite("image/cape7.png");
       backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
       backpack.AddComponent<UseEventTrigger>().Action = () => {
       backpackSprite.sprite = ModAPI.LoadSprite("none.png");

                                                               };

      var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
      var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");

      ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

      person.SetBruiseColor(000, 000, 000);
      person.SetSecondBruiseColor(000, 000, 000);
      person.SetThirdBruiseColor(000, 000, 000);
      person.SetBloodColour(000, 000, 000);
      person.SetRottenColour(000, 000, 000);
                          }
                      }
                  }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Boa Hancock",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Pirate Empress Boa Hancock is the captain of the Kuja Pirates and was the only female Warlord of the Sea prior to the organization's disbandment.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/BoaHancockthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Boa Hancock.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");
   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   arm3.transform.localScale = new Vector3(1.10f, 1.2f);
   arm4.transform.localScale = new Vector3(1.10f, 1.2f);
   arm1.transform.localScale = new Vector3(1.10f, 1.2f);
   arm2.transform.localScale = new Vector3(1.10f, 1.2f);
   leg3.transform.localScale = new Vector3(1.12f, 1.2f);
   leg4.transform.localScale = new Vector3(1.12f, 1.2f);
   leg1.transform.localScale = new Vector3(1.12f, 1.2f);
   leg2.transform.localScale = new Vector3(1.12f, 1.2f);
   foot1.transform.localScale = new Vector3(1.12f, 1.2f);
   foot2.transform.localScale = new Vector3(1.12f, 1.2f);

   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.01f, 0.67f);

   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.064f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.064f, -1.2513f);


   var person = Instance.GetComponent<PersonBehaviour>();
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   head.gameObject.AddComponent<hao>();
   Lower.gameObject.AddComponent<kenbun>();
   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();
   foot1.gameObject.AddComponent<Busoshoku>();
   foot2.gameObject.AddComponent<Busoshoku>();
   foot1.gameObject.AddComponent<petrification>();
   foot2.gameObject.AddComponent<petrification>();


   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
       body.BaseStrength *= 0.2f;
       body.Health *= 1000f;
       body.BreakingThreshold *= 1f;
       body.IsAndroid = true;
       body.transform.root.localScale *= 1f;
       body.gameObject.AddComponent<strongrege>();

       UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger0.Event = new UnityEvent();
       useEventTrigger0.Event.AddListener(delegate ()
        {
          ModAPI.CreateParticleEffect("Vapor", head.transform.position);
         Audio2.Play();
       });
       UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger.Event = new UnityEvent();
       useEventTrigger.Event.AddListener(delegate ()
        {
         body.ImmuneToDamage = true;
         arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
         arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
         Audio.Play();
       });

       UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger2.Event = new UnityEvent();
       useEventTrigger2.Event.AddListener(delegate ()
        {
          Audio3.Play();
       });

       UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger1.Event = new UnityEvent();
       useEventTrigger1.Event.AddListener(delegate ()
        {
          body.ImmuneToDamage = false;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          Audio.Play();
       });


     var bodyuper = Instance.transform.Find("Body").Find("UpperBody");
     bodyuper.localPosition = new Vector3(0.0f, 0.4f);

             Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/Boa Hancockbreast.png");
             Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().material.SetTexture("_FleshTex", ModAPI.LoadTexture("image/Fleshbreast.png"));
             Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().material.SetTexture("_BoneTex", ModAPI.LoadTexture("image/Bonebreast.png"));

          var ca = new GameObject("hancock hair");
          ca.transform.SetParent(Instance.transform.Find("Head"));
          ca.transform.localPosition = new Vector3(0, 0f);
          ca.transform.localScale = new Vector3(1f, 1f);
          var caSprite = ca.AddComponent<SpriteRenderer>();
          caSprite.sprite = ModAPI.LoadSprite("image/hancock hair.png",2.5f);
          ca.GetComponent<SpriteRenderer>().sortingLayerName = "middle";
          ca.AddComponent<UseEventTrigger>().Action = () => {
          caSprite.sprite = ModAPI.LoadSprite("none.png");
          };

          var ornamentobject3 = new GameObject("hancock hair2.png");
          ornamentobject3.transform.SetParent(Instance.transform.Find("Head"));
          ornamentobject3.transform.localPosition = new Vector3(-0.03f, 0.03f);
          ornamentobject3.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
          ornamentobject3.transform.localScale = new Vector3(1f, 1f);
          var ornamentsprite3 = ornamentobject3.AddComponent<SpriteRenderer>();
          ornamentsprite3.sprite = ModAPI.LoadSprite("image/hancock hair2.png",2.8f);
          ornamentsprite3.sortingLayerName = "Top";

          var ornamentobject2 = new GameObject("Boa Hancockcape.png");
          ornamentobject2.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
          ornamentobject2.transform.localPosition = new Vector3(0f, 0f);
          ornamentobject2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
          ornamentobject2.transform.localScale = new Vector3(1f, 1f);
          var ornamentsprite2 = ornamentobject2.AddComponent<SpriteRenderer>();
          ornamentsprite2.sprite = ModAPI.LoadSprite("image/Boa Hancockcape.png");
          ornamentsprite2.sortingLayerName = "Bottom";

          var ca3 = new GameObject("Boa Hancockcape2");
          ca3.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
          ca3.transform.localPosition = new Vector3(0, 0f);
          ca3.transform.localScale = new Vector3(1f, 1f);
          var ca3Sprite = ca3.AddComponent<SpriteRenderer>();
          ca3Sprite.sprite = ModAPI.LoadSprite("image/Boa Hancockcape2.png");
          ca3.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
          ca3.AddComponent<UseEventTrigger>().Action = () => {
          ca3Sprite.sprite = ModAPI.LoadSprite("none.png");
          };

          var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
          var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");

          ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";
          ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";

           }
        }
      }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Gecko Moria",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Gecko Moria is the captain of the Thriller Bark Pirates and a former member of the Seven Warlords of the Sea who resides on the largest ship in the world, Thriller Bark.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Gecko Moriathumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Gecko Moria.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var leg1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.5f, 1.2f);
   middle.transform.localScale = new Vector3(1.6f, 1.2f);
   Lower.transform.localScale = new Vector3(1.7f, 1f);
   arm3.transform.localScale = new Vector3(1.14f, 1.1f);
   arm4.transform.localScale = new Vector3(1.14f, 1.1f);
   arm1.transform.localScale = new Vector3(1.14f, 1.1f);
   arm2.transform.localScale = new Vector3(1.14f, 1.1f);
   leg3.transform.localScale = new Vector3(1.2f, 1f);
   leg4.transform.localScale = new Vector3(1.2f, 1f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);

   arm3.transform.localPosition = new Vector3(0f, -0.12f);
   arm4.transform.localPosition = new Vector3(0f, -0.12f);
   arm1.transform.localPosition = new Vector3(0f, -0.54f);
   arm2.transform.localPosition = new Vector3(0f, -0.54f);

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 1f;
        body.Health *= 50f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1.09f;
        body.PhysicalBehaviour.BurningProgressionMultiplier = -1000000;
        body.gameObject.AddComponent<strongrege>();

        var ornamentobject = new GameObject("moriahair.png");
        ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
        ornamentobject.transform.localPosition = new Vector3(-0.02f, 0.03f);
        ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        ornamentobject.transform.localScale = new Vector3(1f, 1f);
        var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
        ornamentsprite.sprite = ModAPI.LoadSprite("image/moriahair.png",1.3f);
        ornamentsprite.sortingLayerName = "Middle";



      person.SetBodyTextures(skin, flesh, bone, 1);
      person.SetBruiseColor(000, 000, 000); //main bruise colour. purple-ish by default
      person.SetSecondBruiseColor(000, 000, 000); //second bruise colour. red by default
      person.SetThirdBruiseColor(000, 000, 000); // third bruise colour. light yellow by default
      person.SetBloodColour(000, 000, 000); // blood clour. dark red by default
      person.SetRottenColour(000, 000, 000); // rotten/zombie colour. light yellow/green by default




                        }
                    }
                }
);

ModAPI.Register(
  new Modification()
      {
 OriginalItem = ModAPI.FindSpawnable("Human"),
 NameOverride = "Bartholomew Kuma",
 NameToOrderByOverride = "Z1",
 DescriptionOverride = "Bartholomew Kuma is a former Warlord of the Sea, the former king of the Sorbet Kingdom, and a former officer of the Revolutionary Army.",
 CategoryOverride = ModAPI.FindCategory("One Piece pack"),
 ThumbnailOverride = ModAPI.LoadSprite("image/Bartholomew Kumathumbnail.png"),
 AfterSpawn = (Instance) =>
 {

 var skin = ModAPI.LoadTexture("image/Bartholomew Kuma.png");
 var flesh = ModAPI.LoadTexture("Flesh.png");
 var bone = ModAPI.LoadTexture("Bone.png");
 var head = Instance.transform.Find("Head");
 var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
 var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
 var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
 var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
 var leg1 = Instance.transform.Find("FrontLeg").Find("FootFront");
 var leg2 = Instance.transform.Find("BackLeg").Find("Foot");
 var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
 var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
 var upper = Instance.transform.Find("Body").Find("UpperBody");
 var middle = Instance.transform.Find("Body").Find("MiddleBody");
 var Lower = Instance.transform.Find("Body").Find("LowerBody");

 upper.transform.localScale = new Vector3(1.4f, 1.2f);
 middle.transform.localScale = new Vector3(1.3f, 1.2f);
 Lower.transform.localScale = new Vector3(1.2f, 1f);
 arm3.transform.localScale = new Vector3(1.14f, 1.1f);
 arm4.transform.localScale = new Vector3(1.14f, 1.1f);
 arm1.transform.localScale = new Vector3(1.14f, 1.1f);
 arm2.transform.localScale = new Vector3(1.14f, 1.1f);
 leg3.transform.localScale = new Vector3(1.2f, 1f);
 leg4.transform.localScale = new Vector3(1.2f, 1f);
 head.transform.localScale = new Vector3(0.7f, 0.7f);

 head.transform.localPosition = new Vector3(0.02f, 0.700f);

 arm3.transform.localPosition = new Vector3(0f, -0.12f);
 arm4.transform.localPosition = new Vector3(0f, -0.12f);
 arm1.transform.localPosition = new Vector3(0f, -0.54f);
 arm2.transform.localPosition = new Vector3(0f, -0.54f);

 var person = Instance.GetComponent<PersonBehaviour>();

 AudioClip Repulsor = ModAPI.LoadSound("padcannonsound.mp3");
 AudioClip beam2 = ModAPI.LoadSound("padcannonsound.mp3");

 arm1.gameObject.AddComponent<PawPaw1>();
 arm2.gameObject.AddComponent<PawPaw1>();

 foreach (var Limbs in person.Limbs)
 {;

     if (Limbs.GetComponent<GripBehaviour>())
     {
         Limbs.gameObject.AddComponent<UseEventTrigger>().Action = () =>
         {


             AudioSource audio = Limbs.gameObject.AddComponent<AudioSource>();
             audio.spatialBlend = 1;
             audio.PlayOneShot(Repulsor);
         };
     }
 }




 person.SetBodyTextures(skin, flesh, bone, 1);
 foreach (var body in person.Limbs)
  {
      body.BaseStrength *= 1f;
      body.Health *= 1000f;
      body.BreakingThreshold *= 1000f;
      body.IsAndroid = true;
      body.transform.root.localScale *= 1.08f;
      body.PhysicalBehaviour.BurningProgressionMultiplier = -1000000;
      body.gameObject.AddComponent<strongrege>();



  //kumahat
    var ca = new GameObject("kumahat");
    ca.transform.SetParent(Instance.transform.Find("Head"));
    ca.transform.localPosition = new Vector3(0, -0.01f);
    ca.transform.localScale = new Vector3(1f, 1f);
    var caSprite = ca.AddComponent<SpriteRenderer>();
    caSprite.sprite = ModAPI.LoadSprite("image/kumahat.png");
    ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
    ca.AddComponent<UseEventTrigger>().Action = () => {
    caSprite.sprite = ModAPI.LoadSprite("none.png");
    };

    //kumahat2
     var backpack = new GameObject("kumahat2");
     backpack.transform.SetParent(Instance.transform.Find("Head"));
     backpack.transform.localPosition = new Vector3(0, 0f);
     backpack.transform.localScale = new Vector3(1f, 1f);
     var backpackSprite = backpack.AddComponent<SpriteRenderer>();
     backpackSprite.sprite = ModAPI.LoadSprite("image/kumahat2.png");
     backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
     backpack.AddComponent<UseEventTrigger>().Action = () => {
     backpackSprite.sprite = ModAPI.LoadSprite("none.png");

    };

    var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
    var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


    ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
    ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";





    person.SetBodyTextures(skin, flesh, bone, 1);
    person.SetBruiseColor(000, 000, 000); //main bruise colour. purple-ish by default
    person.SetSecondBruiseColor(000, 000, 000); //second bruise colour. red by default
    person.SetThirdBruiseColor(000, 000, 000); // third bruise colour. light yellow by default
    person.SetBloodColour(000, 000, 000); // blood clour. dark red by default
    person.SetRottenColour(000, 000, 000); // rotten/zombie colour. light yellow/green by default




                      }
                  }
              }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Magellan",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Magellan is the vice warden of Impel Down. He was formerly the chief warden,but after his failure to stop the jail's one and only mass-breakout, he was replaced by Hannyabal and demoted to vice warden.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Magellanthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Magellan.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var leg1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.4f, 1.2f);
   middle.transform.localScale = new Vector3(1.3f, 1.2f);
   Lower.transform.localScale = new Vector3(1.2f, 1f);
   arm3.transform.localScale = new Vector3(1.1f, 1f);
   arm4.transform.localScale = new Vector3(1.1f, 1f);
   arm1.transform.localScale = new Vector3(1.1f, 1f);
   arm2.transform.localScale = new Vector3(1.1f, 1f);
   leg3.transform.localScale = new Vector3(1.2f, 1f);
   leg4.transform.localScale = new Vector3(1.2f, 1f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.02f, 0.700f);

   arm3.transform.localPosition = new Vector3(0f, -0.12f);
   arm4.transform.localPosition = new Vector3(0f, -0.12f);
   arm1.transform.localPosition = new Vector3(0f, -0.52f);
   arm2.transform.localPosition = new Vector3(0f, -0.52f);

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 3f;
        body.Health *= 100f;
        body.BreakingThreshold *= 100f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1.06f;
        body.PhysicalBehaviour.BurningProgressionMultiplier = -1000000;
        body.gameObject.AddComponent<strongrege>();
        body.gameObject.AddComponent<Venom>();


        //Magellanhat
          var ca = new GameObject("Magellanhat");
          ca.transform.SetParent(Instance.transform.Find("Head"));
          ca.transform.localPosition = new Vector3(0, 0f);
          ca.transform.localScale = new Vector3(1f, 1f);
          var caSprite = ca.AddComponent<SpriteRenderer>();
          caSprite.sprite = ModAPI.LoadSprite("image/Magellanhat.png");
          ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
          ca.AddComponent<UseEventTrigger>().Action = () => {
          caSprite.sprite = ModAPI.LoadSprite("none.png");
          };

          //Magellanwing
           var backpack = new GameObject("Magellanwing");
           backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
           backpack.transform.localPosition = new Vector3(0, 0f);
           backpack.transform.localScale = new Vector3(1f, 1f);
           var backpackSprite = backpack.AddComponent<SpriteRenderer>();
           backpackSprite.sprite = ModAPI.LoadSprite("image/Magellanwing.png");
           backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
           backpack.AddComponent<UseEventTrigger>().Action = () => {
           backpackSprite.sprite = ModAPI.LoadSprite("none.png");
          };



      var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
      var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


      ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";


                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Buggy",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Buggy the Star Clown is the captain of the Buggy Pirates as well as the co-leader of the Buggy and Alvida Alliance, and a former apprentice of the Roger Pirates.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Buggythumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Buggy.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");
   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");


   upper.transform.localScale = new Vector3(1.2f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);


   var person = Instance.GetComponent<PersonBehaviour>();
   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 1f;
        body.Health *= 20f;
        body.BreakingThreshold *= 1f;
        body.transform.root.localScale *= 1f;
        body.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Wood");

    //
      var ca = new GameObject("Buggyhat");
      ca.transform.SetParent(Instance.transform.Find("Head"));
      ca.transform.localPosition = new Vector3(0, 0f);
      ca.transform.localScale = new Vector3(1f, 1f);
      var caSprite = ca.AddComponent<SpriteRenderer>();
      caSprite.sprite = ModAPI.LoadSprite("image/Buggyhat.png");
      ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ca.AddComponent<UseEventTrigger>().Action = () => {
      caSprite.sprite = ModAPI.LoadSprite("none.png");
      };

      var backpack = new GameObject("buggy cape");
      backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
      backpack.transform.localPosition = new Vector3(0, 0f);
      backpack.transform.localScale = new Vector3(1f, 1f);
      var backpackSprite = backpack.AddComponent<SpriteRenderer>();
      backpackSprite.sprite = ModAPI.LoadSprite("image/buggy cape.png");
      backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
      backpack.AddComponent<UseEventTrigger>().Action = () => {
      backpackSprite.sprite = ModAPI.LoadSprite("none.png");
      };

      var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
      var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


      ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";
      ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";


                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "King",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "King the Conflagration is one of the three All-Stars of the Beasts Pirates, also called Disasters, and is Kaidou's righ hand man, He is a member of the nigh-extinct lunarian race from the Red Line, noted for their ability to create fire.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Kingthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/King.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();
   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.4f, 1.2f);
   middle.transform.localScale = new Vector3(1.2f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.2513f, 1.2f);
   arm4.transform.localScale = new Vector3(1.2513f, 1.2f);
   arm1.transform.localScale = new Vector3(1.2513f, 1.2f);
   arm2.transform.localScale = new Vector3(1.2513f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

Lower.gameObject.AddComponent<kenbun>();
   foot1.gameObject.AddComponent<Firebeh>();
   foot2.gameObject.AddComponent<Firebeh>();
   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();
   leg1.gameObject.AddComponent<Busoshoku>();
   leg2.gameObject.AddComponent<Busoshoku>();

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.5f;
        body.Health *= 1000f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1.08f;
        body.PhysicalBehaviour.BurningProgressionMultiplier = -1000000;
        body.gameObject.AddComponent<strongrege>();
        UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });

        UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger2.Event = new UnityEvent();
        useEventTrigger2.Event.AddListener(delegate ()
         {
           Audio3.Play();
        });

        //Kinghair
          var ca = new GameObject("Kinghair");
          ca.transform.SetParent(Instance.transform.Find("Head"));
          ca.transform.localPosition = new Vector3(0, 0f);
          ca.transform.localScale = new Vector3(1f, 1f);
          var caSprite = ca.AddComponent<SpriteRenderer>();
          caSprite.sprite = ModAPI.LoadSprite("image/Kinghair.png");
          ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
          ca.AddComponent<UseEventTrigger>().Action = () => {
          caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                             };

        //Kingwing
         var backpack = new GameObject("Kingwing");
         backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
         backpack.transform.localPosition = new Vector3(0, 0f);
         backpack.transform.localScale = new Vector3(1f, 1f);
         var backpackSprite = backpack.AddComponent<SpriteRenderer>();
         backpackSprite.sprite = ModAPI.LoadSprite("image/Kingwing.png");
         backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
         backpack.AddComponent<UseEventTrigger>().Action = () => {
         backpackSprite.sprite = ModAPI.LoadSprite("none.png");
        };

        var ornamentobject = new GameObject("Kingsword.png");
        ornamentobject.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
        ornamentobject.transform.localPosition = new Vector3(-0.03f, 0f);
        ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        ornamentobject.transform.localScale = new Vector3(1f, 1f);
        var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
        ornamentsprite.sprite = ModAPI.LoadSprite("image/Kingsword.png",0.9f);
        ornamentsprite.sortingLayerName = "Middle";

        person.SetBodyTextures(skin, flesh, bone, 1);
        person.SetBruiseColor(000, 000, 000); //main bruise colour. purple-ish by default
        person.SetSecondBruiseColor(000, 000, 000); //second bruise colour. red by default
        person.SetThirdBruiseColor(000, 000, 000); // third bruise colour. light yellow by default
        person.SetBloodColour(000, 000, 000); // blood clour. dark red by default
        person.SetRottenColour(000, 000, 000); // rotten/zombie colour. light yellow/green by default

                        }
                    }
                }
);


ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Charlotte Katakuri",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Charlotte Katakuri is the second son and third child of the Charlotte Familyand the elder triplet brother of Daifuku and Oven.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/CharlotteKatakurithumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Charlotte Katakuri.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.4f, 1.2f);
   middle.transform.localScale = new Vector3(1.2f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.2513f, 1.2f);
   arm4.transform.localScale = new Vector3(1.2513f, 1.2f);
   arm1.transform.localScale = new Vector3(1.2513f, 1.2f);
   arm2.transform.localScale = new Vector3(1.2513f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   head.gameObject.AddComponent<hao>();
   Lower.gameObject.AddComponent<kenbun>();
   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();
   leg1.gameObject.AddComponent<Busoshoku>();
   leg2.gameObject.AddComponent<Busoshoku>();

   arm1.gameObject.AddComponent<UseEventTrigger>().Action = () =>
   {
       GameObject Projectile = GameObject.Instantiate(ModAPI.FindSpawnable("Donutfist").Prefab);
       CatalogBehaviour.PerformMod(ModAPI.FindSpawnable("Donutfist"), Projectile);
       Projectile.transform.rotation = arm1.transform.rotation;
       Projectile.transform.eulerAngles += new Vector3(0, 0, -90);
       Projectile.gameObject.GetComponent<PhysicalBehaviour>().SpawnSpawnParticles = false;
       Projectile.transform.position = arm1.transform.position + (-arm1.transform.up * 3.7f);
       Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(Projectile.transform.right * 4000);
       Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(-Projectile.transform.right * -4000);
       var col = Projectile.AddComponent<NoCollide>();
       col.NoCollideSetA = Projectile.GetComponents<Collider2D>();
       col.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();
       Destroy(Projectile, 0.200f);
   };

   arm2.gameObject.AddComponent<UseEventTrigger>().Action = () =>
   {
       GameObject Projectile = GameObject.Instantiate(ModAPI.FindSpawnable("Donutfist").Prefab);
       CatalogBehaviour.PerformMod(ModAPI.FindSpawnable("Donutfist"), Projectile);
       Projectile.transform.rotation = arm2.transform.rotation;
       Projectile.transform.eulerAngles += new Vector3(0, 0, -90);
       Projectile.gameObject.GetComponent<PhysicalBehaviour>().SpawnSpawnParticles = false;
       Projectile.transform.position = arm2.transform.position + (-arm2.transform.up * 3.7f);
       Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(Projectile.transform.right * 4000);
       Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(-Projectile.transform.right * -4000);
       var col = Projectile.AddComponent<NoCollide>();
       col.NoCollideSetA = Projectile.GetComponents<Collider2D>();
       col.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();
       Destroy(Projectile, 0.200f);
   };


   var person = Instance.GetComponent<PersonBehaviour>();
   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.5f;
        body.Health *= 10000f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1.08f;
        body.gameObject.AddComponent<regenstuffnthing>();

        var Hand = new GameObject("Hand");
        Hand.transform.SetParent(Instance.transform.Find("BackArm").Find("UpperArm"));
        Hand.transform.localPosition = new Vector3(0, 0f);
        Hand.transform.localScale = new Vector3(1f, 1f);
        var HandSprite = Hand.AddComponent<SpriteRenderer>();
        HandSprite.sprite = ModAPI.LoadSprite("image/Katakuriarm2.png");
        HandSprite.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";

        var Up = new GameObject("Up");
        Up.transform.SetParent(Instance.transform.Find("BackArm").Find("LowerArm"));
        Up.transform.localPosition = new Vector3(0, 0f);
        Up.transform.localScale = new Vector3(1f, 1f);
        var UpSprite = Up.AddComponent<SpriteRenderer>();
        UpSprite.sprite = ModAPI.LoadSprite("image/Katakuriarm1.png");
        Up.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";

        var Hand2 = new GameObject("Hand2");
        Hand2.transform.SetParent(Instance.transform.Find("BackLeg").Find("UpperLeg"));
        Hand2.transform.localPosition = new Vector3(0, 0f);
        Hand2.transform.localScale = new Vector3(1f, 1f);
        var HandSprite2 = Hand2.AddComponent<SpriteRenderer>();
        HandSprite2.sprite = ModAPI.LoadSprite("image/Katakurileg1.png");
        HandSprite2.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";

        var Up2 = new GameObject("Up2");
        Up2.transform.SetParent(Instance.transform.Find("BackLeg").Find("LowerLeg"));
        Up2.transform.localPosition = new Vector3(0, 0f);
        Up2.transform.localScale = new Vector3(1f, 1f);
        var UpSprite2 = Up2.AddComponent<SpriteRenderer>();
        UpSprite2.sprite = ModAPI.LoadSprite("image/Katakurileg2.png");
        Up2.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";


        UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger0.Event = new UnityEvent();
        useEventTrigger0.Event.AddListener(delegate ()
         {
           ModAPI.CreateParticleEffect("Vapor", head.transform.position);
          Audio2.Play();
        });

        UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.2f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.2f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });

        UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger2.Event = new UnityEvent();
        useEventTrigger2.Event.AddListener(delegate ()
         {
           Audio3.Play();
        });

        var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
        var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");

        ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";


        var ornamentobject = new GameObject("katakurihair.png");
        ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
        ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
        ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        ornamentobject.transform.localScale = new Vector3(1f, 1f);
        var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
        ornamentsprite.sprite = ModAPI.LoadSprite("image/katakurihair.png",2f);
        ornamentsprite.sortingLayerName = "Middle";


        person.SetBodyTextures(skin, flesh, bone, 1);
        person.SetBruiseColor(242, 243, 236);
        person.SetSecondBruiseColor(242, 243, 236);
        person.SetThirdBruiseColor(242, 243, 236);
        person.SetBloodColour(242, 243, 236);
        person.SetRottenColour(242, 243, 236);



           }
        }
    }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Crocodile",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Desert King Sir Crocodile is the former president of the mysterious crime syndicate Baroque Works.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Crocodilethumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Crocodile.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");

   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.3f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   Lower.gameObject.AddComponent<kenbun>();
   arm1.gameObject.AddComponent<Barchan>();

   var horn = GameObject.Instantiate(ModAPI.FindSpawnable("Knife").Prefab);
   horn.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/Chook.png",1,true);
   horn.transform.SetParent(person.Limbs[13].transform);
   horn.transform.position = person.Limbs[13].transform.TransformPoint(new Vector2(0.1f, -0.1f));
   horn.transform.rotation = person.Limbs[13].transform.rotation;
   horn.transform.localPosition = new Vector3(0f, -0.3f, 0);
   horn.transform.localEulerAngles += new Vector3(0, 0, -180);
   horn.transform.localScale = Vector2.one;
   horn.GetComponent<PhysicalBehaviour>().MakeWeightless();
   horn.FixColliders();
   horn.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
   horn.AddComponent<FixedJoint2D>().connectedBody = person.Limbs[13].PhysicalBehaviour.rigidbody;
   horn.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
   var col = horn.AddComponent<NoCollide>();
   col.NoCollideSetA = horn.GetComponents<Collider2D>();
   col.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();
   horn.AddComponent<Pruner>();
   horn.GetComponent<Pruner>().PruneOn = ModAPI.LoadSprite("Image/Chook.png", 1f);
   horn.GetComponent<Pruner>().PruneOff = ModAPI.LoadSprite("Image/Chook2.png", 1f);


   person.SetBodyTextures(skin, flesh, bone, 1);

   foreach (var body in person.Limbs)
    {
       body.BaseStrength *= 0.7f;
       body.Health *= 1000f;
       body.BreakingThreshold *= 1f;
       body.IsAndroid = true;
       body.transform.root.localScale *= 1.01f;
       body.gameObject.AddComponent<strongrege>();

       UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger.Event = new UnityEvent();
       useEventTrigger.Event.AddListener(delegate ()
        {
          body.ImmuneToDamage = true;
          body.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.7f, 0.6f, 0f, 1f);
          head.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.7f, 0.6f, 0f, 1f);

       });

       UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger1.Event = new UnityEvent();
       useEventTrigger1.Event.AddListener(delegate ()
        {
          body.ImmuneToDamage = false;
          body.SkinMaterialHandler.ClearAllDamage();
          body.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          upper.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

       });

       UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger2.Event = new UnityEvent();
       useEventTrigger2.Event.AddListener(delegate ()
        {
          Audio3.Play();
       });

    //cape8
     var backpack = new GameObject("cape8");
     backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
     backpack.transform.localPosition = new Vector3(0, 0f);
     backpack.transform.localScale = new Vector3(1f, 1f);
     var backpackSprite = backpack.AddComponent<SpriteRenderer>();
     backpackSprite.sprite = ModAPI.LoadSprite("image/cape9.png");
     backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
     backpack.AddComponent<UseEventTrigger>().Action = () => {
     backpackSprite.sprite = ModAPI.LoadSprite("none.png");

                                                             };

   //Waxhead
     var ca = new GameObject("Waxhead");
     ca.transform.SetParent(Instance.transform.Find("Head"));
     ca.transform.localPosition = new Vector3(0, 0f);
     ca.transform.localScale = new Vector3(1f, 1f);
     var caSprite = ca.AddComponent<SpriteRenderer>();
     caSprite.sprite = ModAPI.LoadSprite("image/Waxhead.png");
     ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
     ca.AddComponent<UseEventTrigger>().Action = () => {
     caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                        };

    person.SetBodyTextures(skin, flesh, bone, 1);
    person.SetBruiseColor(120, 051, 000);
    person.SetSecondBruiseColor(153, 102, 051);
    person.SetThirdBruiseColor(255, 000, 000);
    person.SetBloodColour(204, 153, 000);
    person.SetRottenColour(000, 000, 000);



           }
        }
     }
  );

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Donquixote Doflamingo",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Donquixote Doflamingo, nicknamed Heavenly Yaksha, is the captain of the Donquixote Pirates.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/DonquixoteDoflamingothumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Donquixote Doflamingo.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");

   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.3f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   AudioClip Repulsor = ModAPI.LoadSound("itotionomi.mp3");
   AudioClip beam2 = ModAPI.LoadSound("itotionomi.mp3");

head.gameObject.AddComponent<hao>();
Lower.gameObject.AddComponent<kenbun>();
   arm1.gameObject.AddComponent<Webs>();
   arm2.gameObject.AddComponent<Webs>();
   leg1.gameObject.AddComponent<Webs>();
   leg2.gameObject.AddComponent<Webs>();
   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();
   leg1.gameObject.AddComponent<Busoshoku>();
   leg2.gameObject.AddComponent<Busoshoku>();

   foreach (var Limbs in person.Limbs)
   {;

       if (Limbs.GetComponent<GripBehaviour>())
       {
           Limbs.gameObject.AddComponent<UseEventTrigger>().Action = () =>
           {


               AudioSource audio = Limbs.gameObject.AddComponent<AudioSource>();
               audio.spatialBlend = 1;
               audio.PlayOneShot(Repulsor);
           };
       }
   }
   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
       body.BaseStrength *= 0.2f;
       body.Health *= 5000f;
       body.BreakingThreshold *= 10f;
       body.IsAndroid = true;
       body.transform.root.localScale *= 1.03f;
       var allColliders = Instance.GetComponentsInChildren<Collider2D>();
       foreach (var a in allColliders)
           foreach (var b in allColliders)
               Physics2D.IgnoreCollision(a, b);
       body.gameObject.AddComponent<strongrege>();


       UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger0.Event = new UnityEvent();
       useEventTrigger0.Event.AddListener(delegate ()
        {
          ModAPI.CreateParticleEffect("Vapor", head.transform.position);
         Audio2.Play();
       });

       UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger.Event = new UnityEvent();
       useEventTrigger.Event.AddListener(delegate ()
        {
         body.ImmuneToDamage = true;
         arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
         arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
         Audio.Play();
       });

       UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger1.Event = new UnityEvent();
       useEventTrigger1.Event.AddListener(delegate ()
        {
          body.ImmuneToDamage = false;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          Audio.Play();
       });

       UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger2.Event = new UnityEvent();
       useEventTrigger2.Event.AddListener(delegate ()
        {
          Audio3.Play();
       });

    //cape8
     var backpack = new GameObject("cape8");
     backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
     backpack.transform.localPosition = new Vector3(0, 0f);
     backpack.transform.localScale = new Vector3(1f, 1f);
     var backpackSprite = backpack.AddComponent<SpriteRenderer>();
     backpackSprite.sprite = ModAPI.LoadSprite("image/cape8.png");
     backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
     backpack.AddComponent<UseEventTrigger>().Action = () => {
     backpackSprite.sprite = ModAPI.LoadSprite("none.png");
                                                              };

     var ornamentobject = new GameObject("Donquixote Doflamingohair.png");
     ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
     ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
     ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
     ornamentobject.transform.localScale = new Vector3(1f, 1f);
     var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
     ornamentsprite.sprite = ModAPI.LoadSprite("image/Donquixote Doflamingohair.png",2f);
     ornamentsprite.sortingLayerName = "Middle";

    }

    arm1.gameObject.GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("ena", "Enable Penta-Chromatic String", "Enable Penta-Chromatic String", new UnityAction[1]
    {
        (UnityAction) (() =>
        {
          GameObject Projectile2 = GameObject.Instantiate(ModAPI.FindSpawnable("Penta-Chromatic String").Prefab);
          CatalogBehaviour.PerformMod(ModAPI.FindSpawnable("Penta-Chromatic String"), Projectile2);
          Projectile2.transform.SetParent(arm1.gameObject.transform);
          Projectile2.transform.position = arm1.transform.position + (-arm1.transform.up * 1f);
          Projectile2.transform.localPosition = new Vector3(0f, -0.28f);
          Projectile2.transform.eulerAngles = arm1.transform.eulerAngles;
          Projectile2.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";

          Projectile2.gameObject.GetComponent<PhysicalBehaviour>().SpawnSpawnParticles = false;
          Projectile2.gameObject.AddComponent<FixedJoint2D>();
          Projectile2.gameObject.GetComponent<FixedJoint2D>().connectedBody = arm1.gameObject.GetComponent<Rigidbody2D>();
          var col = Projectile2.AddComponent<NoCollide>();
          col.NoCollideSetA = Projectile2.GetComponents<Collider2D>();
          col.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

    arm1.gameObject.GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("disa", "Disable Penta-Chromatic String", "Disable Penta-Chromatic String", new UnityAction[1]
    {
        (UnityAction) (() =>
        {
          Destroy(Projectile2);
        })
    }));

    })
    }));

    arm2.gameObject.GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("ena", "Enable Penta-Chromatic String", "Enable Penta-Chromatic String", new UnityAction[1]
    {
        (UnityAction) (() =>
        {
          GameObject Projectile2 = GameObject.Instantiate(ModAPI.FindSpawnable("Penta-Chromatic String").Prefab);
          CatalogBehaviour.PerformMod(ModAPI.FindSpawnable("Penta-Chromatic String"), Projectile2);
          Projectile2.transform.SetParent(arm2.gameObject.transform);
          Projectile2.transform.position = arm2.transform.position + (-arm2.transform.up * 1f);
          Projectile2.transform.localPosition = new Vector3(0f, -0.28f);
          Projectile2.transform.eulerAngles = arm2.transform.eulerAngles;

          Projectile2.gameObject.GetComponent<PhysicalBehaviour>().SpawnSpawnParticles = false;
          Projectile2.gameObject.AddComponent<FixedJoint2D>();
          Projectile2.gameObject.GetComponent<FixedJoint2D>().connectedBody = arm2.gameObject.GetComponent<Rigidbody2D>();
          var col = Projectile2.AddComponent<NoCollide>();
          col.NoCollideSetA = Projectile2.GetComponents<Collider2D>();
          col.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

    arm2.gameObject.GetComponent<PhysicalBehaviour>().ContextMenuOptions.Buttons.Add(new ContextMenuButton("disa", "Disable Penta-Chromatic String", "Disable Penta-Chromatic String", new UnityAction[1]
    {
        (UnityAction) (() =>
        {
          Destroy(Projectile2);
        })
    }));

    })
    }));

        }
     }
 );

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Trafalgar D. Water Law",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Trafalgar D. Water Law, by his epithet as the Surgeon of Death, is a pirate from North Blue and the captain and doctor of the Heart Pirates. He is one of twelve pirates who are referred to as the Worst Generation.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Lawthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

     var skin = ModAPI.LoadTexture("image/Trafalgar D. Water Law.png");
     var flesh = ModAPI.LoadTexture("Flesh.png");
     var bone = ModAPI.LoadTexture("Bone.png");


     var person = Instance.GetComponent<PersonBehaviour>();

     var head = Instance.transform.Find("Head");
     var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
     var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
     var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
     var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
     var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
     var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
     var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
     var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
     var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
     var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
     var upper = Instance.transform.Find("Body").Find("UpperBody");
     var middle = Instance.transform.Find("Body").Find("MiddleBody");
     var Lower = Instance.transform.Find("Body").Find("LowerBody");

     upper.transform.localScale = new Vector3(1.3f, 1.2f);
     middle.transform.localScale = new Vector3(1.1f, 1.2f);
     head.transform.localScale = new Vector3(0.7f, 0.7f);
     arm3.transform.localScale = new Vector3(1.18f, 1.2f);
     arm4.transform.localScale = new Vector3(1.18f, 1.2f);
     arm1.transform.localScale = new Vector3(1.18f, 1.2f);
     arm2.transform.localScale = new Vector3(1.18f, 1.2f);
     leg3.transform.localScale = new Vector3(1.19f, 1.2f);
     leg4.transform.localScale = new Vector3(1.19f, 1.2f);
     leg1.transform.localScale = new Vector3(1.19f, 1.2f);
     leg2.transform.localScale = new Vector3(1.19f, 1.2f);
     foot1.transform.localScale = new Vector3(1.19f, 1.2f);
     foot2.transform.localScale = new Vector3(1.19f, 1.2f);

     head.transform.localPosition = new Vector3(0.01f, 0.700f);
     arm3.transform.localPosition = new Vector3(0f, -0.15f);
     arm4.transform.localPosition = new Vector3(0f, -0.15f);
     arm1.transform.localPosition = new Vector3(0f, -0.60f);
     arm2.transform.localPosition = new Vector3(0f, -0.60f);
     leg3.transform.localPosition = new Vector3(0f, -0.46f);
     leg4.transform.localPosition = new Vector3(0f, -0.46f);
     leg1.transform.localPosition = new Vector3(0f, -0.96f);
     leg2.transform.localPosition = new Vector3(0f, -0.96f);
     foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
     foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);


Lower.gameObject.AddComponent<kenbun>();
     arm1.gameObject.AddComponent<openomi>();
     arm2.gameObject.AddComponent<openomi>();

   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");


   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.3f;
        body.Health *= 1000f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1.01f;
        body.PhysicalBehaviour.BurningProgressionMultiplier = -1000000;
        body.gameObject.AddComponent<strongrege>();
        UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });


        UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger2.Event = new UnityEvent();
        useEventTrigger2.Event.AddListener(delegate ()
         {
           Audio3.Play();
        });

    //Lawhat
      var ca = new GameObject("Lawhat");
      ca.transform.SetParent(Instance.transform.Find("Head"));
      ca.transform.localPosition = new Vector3(0, 0f);
      ca.transform.localScale = new Vector3(1f, 1f);
      var caSprite = ca.AddComponent<SpriteRenderer>();
      caSprite.sprite = ModAPI.LoadSprite("image/Lawhat.png");
      ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ca.AddComponent<UseEventTrigger>().Action = () => {
      caSprite.sprite = ModAPI.LoadSprite("none.png");
      };

      //cape22
       var backpack = new GameObject("cape22");
       backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
       backpack.transform.localPosition = new Vector3(0, 0f);
       backpack.transform.localScale = new Vector3(1f, 1f);
       var backpackSprite = backpack.AddComponent<SpriteRenderer>();
       backpackSprite.sprite = ModAPI.LoadSprite("image/cape22.png");
       backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
       backpack.AddComponent<UseEventTrigger>().Action = () => {
       backpackSprite.sprite = ModAPI.LoadSprite("none.png");

      };

      var ornamentobject = new GameObject("Lawhair.png");
      ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
      ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
      ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
      ornamentobject.transform.localScale = new Vector3(1f, 1f);
      var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
      ornamentsprite.sprite = ModAPI.LoadSprite("image/Lawhair.png",2f);
      ornamentsprite.sortingLayerName = "Middle";

      var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
      var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


      ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";


                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Eustass Kid",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Eustass  Captain Kid is a notorious pirate from South Blue and the captain of the Kid Pirates. He is one of twelve pirates who are referred to as the Worst Generation.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/EustassKidthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Eustass Kid.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.4f, 1.2f);
   middle.transform.localScale = new Vector3(1.3f, 1.2f);
   Lower.transform.localScale = new Vector3(1.2f, 1f);
   arm3.transform.localScale = new Vector3(1.3f, 1.2f);
   arm4.transform.localScale = new Vector3(2f, 1.7f);
   arm1.transform.localScale = new Vector3(1.3f, 1.2f);
   arm2.transform.localScale = new Vector3(2f, 1.7f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.23f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.85f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);

   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

Lower.gameObject.AddComponent<kenbun>();
   head.gameObject.AddComponent<hao>();
   arm2.gameObject.AddComponent<Busoshoku>();
   arm1.gameObject.AddComponent<jikinomi>();
   arm2.gameObject.AddComponent<jikinomi>();

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
       body.BaseStrength *= 0.5f;
       body.Health *= 100f;
       body.BreakingThreshold *= 100f;
       body.IsAndroid = true;
       body.transform.root.localScale *= 1.02f;
       body.gameObject.AddComponent<strongrege>();

       var Hand = new GameObject("Hand");
       Hand.transform.SetParent(Instance.transform.Find("BackArm").Find("UpperArm"));
       Hand.transform.localPosition = new Vector3(0, 0f);
       Hand.transform.localScale = new Vector3(1f, 1f);
       var HandSprite = Hand.AddComponent<SpriteRenderer>();
       HandSprite.sprite = ModAPI.LoadSprite("image/Kidarm2.png");
       HandSprite.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";

       var Up = new GameObject("Hand");
       Up.transform.SetParent(Instance.transform.Find("BackArm").Find("LowerArm"));
       Up.transform.localPosition = new Vector3(0, 0f);
       Up.transform.localScale = new Vector3(1f, 1f);
       var UpSprite = Up.AddComponent<SpriteRenderer>();
       UpSprite.sprite = ModAPI.LoadSprite("image/Kidarm1.png");
       Up.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";

       UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger0.Event = new UnityEvent();
       useEventTrigger0.Event.AddListener(delegate ()
        {
          ModAPI.CreateParticleEffect("Vapor", head.transform.position);
         Audio2.Play();
       });

       UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger.Event = new UnityEvent();
       useEventTrigger.Event.AddListener(delegate ()
        {
         body.ImmuneToDamage = true;
         arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
         Audio.Play();
       });

       UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger1.Event = new UnityEvent();
       useEventTrigger1.Event.AddListener(delegate ()
        {
          body.ImmuneToDamage = false;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          Audio.Play();
       });

       UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger2.Event = new UnityEvent();
       useEventTrigger2.Event.AddListener(delegate ()
        {
          Audio3.Play();
       });

       var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
       var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");

       ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
       ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

       var ornamentobject = new GameObject("Kidhair.png");
       ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
       ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
       ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
       ornamentobject.transform.localScale = new Vector3(1f, 1f);
       var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
       ornamentsprite.sprite = ModAPI.LoadSprite("image/Kidhair.png",2f);
       ornamentsprite.sortingLayerName = "Top";



     var ca2 = new GameObject("Kidcape.png");
     ca2.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
     ca2.transform.localPosition = new Vector3(0, 0f);
     ca2.transform.localScale = new Vector3(1f, 1f);
     var ca2Sprite = ca2.AddComponent<SpriteRenderer>();
     ca2Sprite.sprite = ModAPI.LoadSprite("image/Kidcape.png");
     ca2.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
     ca2.AddComponent<UseEventTrigger>().Action = () => {
     ca2Sprite.sprite = ModAPI.LoadSprite("none.png");
                                                       };


      person.SetBruiseColor(255, 255, 000);
      person.SetSecondBruiseColor(255, 255, 102);
      person.SetThirdBruiseColor(255, 255, 153);
      person.SetBloodColour(255, 255, 204);
      person.SetRottenColour(000, 000, 000);

           }
        }
     }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Killer",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Killer is a pirate from the South Blue and a combatant of the Kid Pirates. He is one of twelve pirates who are referred to as the Worst Generation.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/killerthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Killer.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.2f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   GameObject horn = GameObject.Instantiate(ModAPI.FindSpawnable("Knife").Prefab);
   horn.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/killerpunisher.png",1f,true);
   horn.transform.SetParent(person.Limbs[13].transform);
   horn.transform.position = person.Limbs[13].transform.TransformPoint(new Vector2(0f, -0f));
   horn.transform.rotation = person.Limbs[13].transform.rotation;
   horn.transform.localPosition = new Vector3(-0.1f, -0.53f, 0);
   horn.transform.localEulerAngles += new Vector3(0, 0, -180);
   horn.transform.localScale = Vector2.one;
   horn.GetComponent<PhysicalBehaviour>().MakeWeightless();
   horn.FixColliders();
   horn.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
   horn.AddComponent<FixedJoint2D>().connectedBody = person.Limbs[13].PhysicalBehaviour.rigidbody;
   horn.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
   var col = horn.AddComponent<NoCollide>();
   col.NoCollideSetA = horn.GetComponents<Collider2D>();
   col.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

   GameObject horn2 = GameObject.Instantiate(ModAPI.FindSpawnable("Knife").Prefab);
   horn2.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/killerpunisher.png",1f,true);
   horn2.transform.SetParent(person.Limbs[11].transform);
   horn2.transform.position = person.Limbs[11].transform.TransformPoint(new Vector2(0f, -0f));
   horn2.transform.rotation = person.Limbs[11].transform.rotation;
   horn2.transform.localPosition = new Vector3(-0.1f, -0.53f, 0);
   horn2.transform.localEulerAngles += new Vector3(0, 0, -180);
   horn2.transform.localScale = Vector2.one;
   horn2.GetComponent<PhysicalBehaviour>().MakeWeightless();
   horn2.FixColliders();
   horn2.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";
   horn2.AddComponent<FixedJoint2D>().connectedBody = person.Limbs[11].PhysicalBehaviour.rigidbody;
   horn2.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
   var col2 = horn2.AddComponent<NoCollide>();
   col2.NoCollideSetA = horn2.GetComponents<Collider2D>();
   col2.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.3f;
        body.Health *= 1000f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1.01f;

        UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });


      var ca = new GameObject("killerhair");
      ca.transform.SetParent(Instance.transform.Find("Head"));
      ca.transform.localPosition = new Vector3(0, 0f);
      ca.transform.localScale = new Vector3(1f, 1f);
      var caSprite = ca.AddComponent<SpriteRenderer>();
      caSprite.sprite = ModAPI.LoadSprite("image/killerhair.png",2.5f);
      ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
      ca.AddComponent<UseEventTrigger>().Action = () => {
      caSprite.sprite = ModAPI.LoadSprite("none.png");
      };

      var ornamentobject3 = new GameObject("killerbeard.png");
      ornamentobject3.transform.SetParent(Instance.transform.Find("Head"));
      ornamentobject3.transform.localPosition = new Vector3(0f, 0f);
      ornamentobject3.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
      ornamentobject3.transform.localScale = new Vector3(1f, 1f);
      var ornamentsprite3 = ornamentobject3.AddComponent<SpriteRenderer>();
      ornamentsprite3.sprite = ModAPI.LoadSprite("image/killerbeard.png");
      ornamentsprite3.sortingLayerName = "Top";

      var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
      var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");

      ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Urouge",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Urouge nicknamed the Mad Monk, is a pirate hailing from a sky island and captain of the Fallen Monk Pirates He is one of twelve pirates referred to as the Worst Generation.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Urougethumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Urouge.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");
   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var leg1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.5f, 1.2f);
   middle.transform.localScale = new Vector3(1.4f, 1.2f);
   Lower.transform.localScale = new Vector3(1.3f, 1.2f);
   arm3.transform.localScale = new Vector3(1.7f, 1.2513f);
   arm4.transform.localScale = new Vector3(1.7f, 1.2513f);
   arm1.transform.localScale = new Vector3(1.7f, 1.3f);
   arm2.transform.localScale = new Vector3(1.7f, 1.3f);
   leg3.transform.localScale = new Vector3(1.3f, 1f);
   leg4.transform.localScale = new Vector3(1.3f, 1f);

   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.02f, 0.700f);

   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.61f);
   arm2.transform.localPosition = new Vector3(0f, -0.61f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   var person = Instance.GetComponent<PersonBehaviour>();
   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 1f;
        body.Health *= 100f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1.03f;
        body.gameObject.AddComponent<strongrege>();
        UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });



        var ca = new GameObject("Urougehair");
        ca.transform.SetParent(Instance.transform.Find("Head"));
        ca.transform.localPosition = new Vector3(0, 0f);
        ca.transform.localScale = new Vector3(1f, 1f);
        var caSprite = ca.AddComponent<SpriteRenderer>();
        caSprite.sprite = ModAPI.LoadSprite("image/Urougehair.png");
        ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        ca.AddComponent<UseEventTrigger>().Action = () => {
        caSprite.sprite = ModAPI.LoadSprite("none.png");
        };

        var ca2 = new GameObject("Urougewing");
        ca2.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
        ca2.transform.localPosition = new Vector3(0, 0f);
        ca2.transform.localScale = new Vector3(1f, 1f);
        var ca2Sprite = ca2.AddComponent<SpriteRenderer>();
        ca2Sprite.sprite = ModAPI.LoadSprite("image/Urougewing.png");
        ca2.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
        ca2.AddComponent<UseEventTrigger>().Action = () => {
        ca2Sprite.sprite = ModAPI.LoadSprite("none.png");
        };

        var ca3 = new GameObject("Urougecape");
        ca3.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
        ca3.transform.localPosition = new Vector3(0, 0f);
        ca3.transform.localScale = new Vector3(1f, 1f);
        var ca3Sprite = ca3.AddComponent<SpriteRenderer>();
        ca3Sprite.sprite = ModAPI.LoadSprite("image/Urougecape.png");
        ca3.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
        ca3.AddComponent<UseEventTrigger>().Action = () => {
        ca3Sprite.sprite = ModAPI.LoadSprite("none.png");
      };

      var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
      var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


      ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";


                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Basil Hawkins",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Basil Hawkins is an infamous pirate from North Blue known as the Magician and the captain of the Hawkins Pirates. He is one of twelve pirates who are referred to as the Worst Generation.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/BasilHawkinsthumb.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Basil Hawkins.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.2f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");




   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.3f;
        body.Health *= 1000f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1.01f;

        UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });


      var ca = new GameObject("BasilHawkinshair");
      ca.transform.SetParent(Instance.transform.Find("Head"));
      ca.transform.localPosition = new Vector3(0, 0f);
      ca.transform.localScale = new Vector3(1f, 1f);
      var caSprite = ca.AddComponent<SpriteRenderer>();
      caSprite.sprite = ModAPI.LoadSprite("image/BasilHawkinshair.png");
      ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
      ca.AddComponent<UseEventTrigger>().Action = () => {
      caSprite.sprite = ModAPI.LoadSprite("none.png");
      };


       var backpack = new GameObject("BasilHawkinscape");
       backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
       backpack.transform.localPosition = new Vector3(0, 0f);
       backpack.transform.localScale = new Vector3(1f, 1f);
       var backpackSprite = backpack.AddComponent<SpriteRenderer>();
       backpackSprite.sprite = ModAPI.LoadSprite("image/BasilHawkinscape.png");
       backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
       backpack.AddComponent<UseEventTrigger>().Action = () => {
       backpackSprite.sprite = ModAPI.LoadSprite("none.png");

      };

      var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
      var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


      ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";




                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "X Drake",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Red Flag X Drake (read as Diez Drake) is the captain of the Marine Secret Special Unit SWORD.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/X Drakethumb.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/X Drake.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.2f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.3f;
        body.Health *= 1000f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1.01f;
        UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });


      var ca = new GameObject("X Drakehair");
      ca.transform.SetParent(Instance.transform.Find("Head"));
      ca.transform.localPosition = new Vector3(0, 0f);
      ca.transform.localScale = new Vector3(1f, 1f);
      var caSprite = ca.AddComponent<SpriteRenderer>();
      caSprite.sprite = ModAPI.LoadSprite("image/X Drakehair.png",2f);
      ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
      ca.AddComponent<UseEventTrigger>().Action = () => {
      caSprite.sprite = ModAPI.LoadSprite("none.png");
      };


       var backpack = new GameObject("X Drakecape");
       backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
       backpack.transform.localPosition = new Vector3(0, 0f);
       backpack.transform.localScale = new Vector3(1f, 1f);
       var backpackSprite = backpack.AddComponent<SpriteRenderer>();
       backpackSprite.sprite = ModAPI.LoadSprite("image/X Drakecape.png");
       backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
       backpack.AddComponent<UseEventTrigger>().Action = () => {
       backpackSprite.sprite = ModAPI.LoadSprite("none.png");

      };

      var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
      var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


      ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";




                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Rob Lucci",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Rob Lucci is a current member of CP0.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Rob Luccihatthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Rob Lucci.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");

   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.2f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);


   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");


   Lower.gameObject.AddComponent<kenbun>();

   var component = arm1.GetComponent<PhysicalBehaviour>();
   var chelovek = ModAPI.FindPhysicalProperties("Human");
   chelovek.Sharp = true;
   chelovek.SharpAxes = new[]
   {
                           new SharpAxis(Vector2.down, 0f, 0.55f, false, true),
                       };
   component.Properties = chelovek;
   var component2 = arm2.GetComponent<PhysicalBehaviour>();
   component2.Properties = chelovek;

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.3f;
        body.Health *= 1000f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1.01f;
        body.PhysicalBehaviour.BurningProgressionMultiplier = -1000000;
        body.gameObject.AddComponent<strongrege>();
        UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });


    //Sabohat
      var ca = new GameObject("Rob Luccihat");
      ca.transform.SetParent(Instance.transform.Find("Head"));
      ca.transform.localPosition = new Vector3(0, 0f);
      ca.transform.localScale = new Vector3(1f, 1f);
      var caSprite = ca.AddComponent<SpriteRenderer>();
      caSprite.sprite = ModAPI.LoadSprite("image/Rob Luccihat.png");
      ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ca.AddComponent<UseEventTrigger>().Action = () => {
      caSprite.sprite = ModAPI.LoadSprite("none.png");
      };

      var ca2 = new GameObject("Rob Luccihair.png");
      ca2.transform.SetParent(Instance.transform.Find("Head"));
      ca2.transform.localPosition = new Vector3(0, 0f);
      ca2.transform.localScale = new Vector3(1f, 1f);
      var ca2Sprite = ca2.AddComponent<SpriteRenderer>();
      ca2Sprite.sprite = ModAPI.LoadSprite("image/Rob Luccihair.png");
      ca2.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
      ca2.AddComponent<UseEventTrigger>().Action = () => {
      ca2Sprite.sprite = ModAPI.LoadSprite("none.png");
      };

      var ca3 = new GameObject("Sabocape.png");
      ca3.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
      ca3.transform.localPosition = new Vector3(0, 0f);
      ca3.transform.localScale = new Vector3(1f, 1f);
      var ca3Sprite = ca3.AddComponent<SpriteRenderer>();
      ca3Sprite.sprite = ModAPI.LoadSprite("image/Rob Luccicape.png");
      ca3.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
      ca3.AddComponent<UseEventTrigger>().Action = () => {
      ca3Sprite.sprite = ModAPI.LoadSprite("none.png");
      };

      var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
      var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


      ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Capone Bege",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Capone Gang Bege is a mafia don-turned-pirate and the captain of the Fire Tank Pirates. He is also one of twelve pirates who are referred to as the Worst Generation.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/CaponeBegethumb.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Capone Bege.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.4f, 1.1f);
   middle.transform.localScale = new Vector3(1.4f, 1.1f);
   Lower.transform.localScale = new Vector3(1.4f, 1.1f);

   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.2f, 1.1f);
   arm4.transform.localScale = new Vector3(1.2f, 1.1f);
   arm1.transform.localScale = new Vector3(1.2f, 1.1f);
   arm2.transform.localScale = new Vector3(1.2f, 1.1f);
   leg3.transform.localScale = new Vector3(1.2f, 1.1f);
   leg4.transform.localScale = new Vector3(1.2f, 1.1f);
   leg1.transform.localScale = new Vector3(1.2f, 1.1f);
   leg2.transform.localScale = new Vector3(1.2f, 1.1f);


   head.transform.localPosition = new Vector3(0.01f, 0.70f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");




   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.3f;
        body.Health *= 1000f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1f;
        UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });


      var ca = new GameObject("CaponeBegehat");
      ca.transform.SetParent(Instance.transform.Find("Head"));
      ca.transform.localPosition = new Vector3(0, 0f);
      ca.transform.localScale = new Vector3(1f, 1f);
      var caSprite = ca.AddComponent<SpriteRenderer>();
      caSprite.sprite = ModAPI.LoadSprite("image/CaponeBegehat.png");
      ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ca.AddComponent<UseEventTrigger>().Action = () => {
      caSprite.sprite = ModAPI.LoadSprite("none.png");
      };


       var backpack = new GameObject("CaponeBegecape");
       backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
       backpack.transform.localPosition = new Vector3(0, 0f);
       backpack.transform.localScale = new Vector3(1f, 1f);
       var backpackSprite = backpack.AddComponent<SpriteRenderer>();
       backpackSprite.sprite = ModAPI.LoadSprite("image/CaponeBegecape.png");
       backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
       backpack.AddComponent<UseEventTrigger>().Action = () => {
       backpackSprite.sprite = ModAPI.LoadSprite("none.png");

      };

      var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
      var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


      ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";




                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Jewelry Bonney",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Jewelry Bonney, also known as the Big Eater, is a pirate and the captain of the Bonney Pirates. She and her crew originated from South Blue. She is one of twelve pirates who are referred to as the Worst Generation.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/JewelryBonneythumb.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Jewelry Bonney.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   leg3.transform.localScale = new Vector3(1.12f, 1.2f);
   leg4.transform.localScale = new Vector3(1.12f, 1.2f);
   leg1.transform.localScale = new Vector3(1.12f, 1.2f);
   leg2.transform.localScale = new Vector3(1.12f, 1.2f);
   foot1.transform.localScale = new Vector3(1.12f, 1.2f);
   foot2.transform.localScale = new Vector3(1.12f, 1.2f);


   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.064f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.064f, -1.2513f);

   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.01f, 0.67f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");


   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();
   leg1.gameObject.AddComponent<Busoshoku>();
   leg2.gameObject.AddComponent<Busoshoku>();
   leg1.gameObject.AddComponent<petrification>();
   leg2.gameObject.AddComponent<Busoshoku>();

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
       body.BaseStrength *= 0.2f;
       body.Health *= 1000f;
       body.BreakingThreshold *= 1f;
       body.IsAndroid = true;
       body.transform.root.localScale *= 1f;
       UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger.Event = new UnityEvent();
       useEventTrigger.Event.AddListener(delegate ()
        {
         body.ImmuneToDamage = true;
         arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
         arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
         Audio.Play();
       });

       UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger1.Event = new UnityEvent();
       useEventTrigger1.Event.AddListener(delegate ()
        {
          body.ImmuneToDamage = false;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          Audio.Play();
       });


     var bodyuper = Instance.transform.Find("Body").Find("UpperBody");
     bodyuper.localPosition = new Vector3(0.0f, 0.4f);

             Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/Jewelry Bonneybreast.png");
             Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().material.SetTexture("_FleshTex", ModAPI.LoadTexture("image/Fleshbreast.png"));
             Instance.transform.Find("Body").Find("UpperBody").GetComponent<SpriteRenderer>().material.SetTexture("_BoneTex", ModAPI.LoadTexture("image/Bonebreast.png"));


          var ca = new GameObject("Bonneyhair");
          ca.transform.SetParent(Instance.transform.Find("Head"));
          ca.transform.localPosition = new Vector3(0, 0f);
          ca.transform.localScale = new Vector3(1f, 1f);
          var caSprite = ca.AddComponent<SpriteRenderer>();
          caSprite.sprite = ModAPI.LoadSprite("image/Bonneyhair.png");
          ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
          ca.AddComponent<UseEventTrigger>().Action = () => {
          caSprite.sprite = ModAPI.LoadSprite("none.png");
          };

          var ca2 = new GameObject("Bonneyhat");
          ca2.transform.SetParent(Instance.transform.Find("Head"));
          ca2.transform.localPosition = new Vector3(0, 0f);
          ca2.transform.localScale = new Vector3(1f, 1f);
          var ca2Sprite = ca2.AddComponent<SpriteRenderer>();
          ca2Sprite.sprite = ModAPI.LoadSprite("image/Bonneyhat.png");
          ca2.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
          ca2.AddComponent<UseEventTrigger>().Action = () => {
          ca2Sprite.sprite = ModAPI.LoadSprite("none.png");
          };




           }
        }
      }
);
            ModAPI.Register(
                new Modification()
                    {
               OriginalItem = ModAPI.FindSpawnable("Human"),
               NameOverride = "Otama",
               NameToOrderByOverride = "Z1",
               DescriptionOverride = "O-Tama is a girl from the region of Kuri in Wano Country. She is a kasa weaver and a kunoichi in training, working under Tenguyama Hitetsu.",
               CategoryOverride = ModAPI.FindCategory("One Piece pack"),
               ThumbnailOverride = ModAPI.LoadSprite("image/otamathumbnail.png"),
               AfterSpawn = (Instance) =>
               {

               var skin = ModAPI.LoadTexture("image/Otama.png");
               var flesh = ModAPI.LoadTexture("Flesh.png");
               var bone = ModAPI.LoadTexture("Bone.png");
               var head = Instance.transform.Find("Head");
               var Lower = Instance.transform.Find("Body").Find("LowerBody");

               head.transform.localScale = new Vector3(1.2f, 1.2f);
               head.transform.localPosition = new Vector3(0.001f, 0.75f);

               var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
               var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


               ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
               ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

               var person = Instance.GetComponent<PersonBehaviour>();
               person.SetBodyTextures(skin, flesh, bone, 1);
               foreach (var body in person.Limbs)
                {
                    body.BaseStrength *= 0.3f;
                    body.Health *= 10f;
                    body.BreakingThreshold *= 1f;
                    body.transform.root.localScale *= 0.97f;


                  var ca = new GameObject("otamahair");
                  ca.transform.SetParent(Instance.transform.Find("Head"));
                  ca.transform.localPosition = new Vector3(0, 0f);
                  ca.transform.localScale = new Vector3(1f, 1f);
                  var caSprite = ca.AddComponent<SpriteRenderer>();
                  caSprite.sprite = ModAPI.LoadSprite("image/otamahair.png");
                  ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
                  ca.AddComponent<UseEventTrigger>().Action = () => {
                  caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                                    };

                  var ca2 = new GameObject("otamacape");
                  ca2.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
                  ca2.transform.localPosition = new Vector3(0, 0f);
                  ca2.transform.localScale = new Vector3(1f, 1f);
                  var ca2Sprite = ca2.AddComponent<SpriteRenderer>();
                  ca2Sprite.sprite = ModAPI.LoadSprite("image/otamacape.png");
                  ca2.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
                  ca2.AddComponent<UseEventTrigger>().Action = () => {
                  ca2Sprite.sprite = ModAPI.LoadSprite("none.png");
                                                                    };

                                    }
                                }
                            }
            );

            ModAPI.Register(
                  new Modification()
                      {
                 OriginalItem = ModAPI.FindSpawnable("Human"),
                 NameOverride = "Saint Shalria",
                 NameToOrderByOverride = "Z1",
                 DescriptionOverride = "Saint Shalria  is a World Noble, the younger sister of Saint Charlos, and the daughter of Saint Rosward.",
                 CategoryOverride = ModAPI.FindCategory("One Piece pack"),
                 ThumbnailOverride = ModAPI.LoadSprite("image/SaintShalriathumbnail.png"),
                 AfterSpawn = (Instance) =>
                 {

                 var skin = ModAPI.LoadTexture("image/Saint Shalria.png");
                 var flesh = ModAPI.LoadTexture("Flesh.png");
                 var bone = ModAPI.LoadTexture("Bone.png");
                 var head = Instance.transform.Find("Head");
                 var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
                 var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
                 var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
                 var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
                 var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
                 var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
                 var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
                 var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
                 var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
                 var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
                 var upper = Instance.transform.Find("Body").Find("UpperBody");
                 var middle = Instance.transform.Find("Body").Find("MiddleBody");
                 var Lower = Instance.transform.Find("Body").Find("LowerBody");

                 upper.transform.localScale = new Vector3(1.2f, 1.1f);
                 middle.transform.localScale = new Vector3(1.3f, 1.1f);
                 Lower.transform.localScale = new Vector3(1.3f, 1.1f);
                 leg3.transform.localScale = new Vector3(1.12f, 1.2f);
                 leg4.transform.localScale = new Vector3(1.12f, 1.2f);
                 leg1.transform.localScale = new Vector3(1.12f, 1.2f);
                 leg2.transform.localScale = new Vector3(1.12f, 1.2f);
                 foot1.transform.localScale = new Vector3(1.12f, 1.2f);
                 foot2.transform.localScale = new Vector3(1.12f, 1.2f);

                 head.transform.localScale = new Vector3(0.7f, 0.7f);

                 head.transform.localPosition = new Vector3(0.01f, 0.700f);

                 upper.transform.localPosition = new Vector3(0f, 0.45f);
                 leg3.transform.localPosition = new Vector3(0f, -0.46f);
                 leg4.transform.localPosition = new Vector3(0f, -0.46f);
                 leg1.transform.localPosition = new Vector3(0f, -0.96f);
                 leg2.transform.localPosition = new Vector3(0f, -0.96f);
                 foot1.transform.localPosition = new Vector3(0.064f, -1.2513f);
                 foot2.transform.localPosition = new Vector3(0.064f, -1.2513f);

                 var person = Instance.GetComponent<PersonBehaviour>();
                 person.SetBodyTextures(skin, flesh, bone, 1);
                 foreach (var body in person.Limbs)
                  {
                      body.BaseStrength *= 1f;
                      body.Health *= 8f;
                      body.BreakingThreshold *= 1f;
                      body.transform.root.localScale *= 1f;

                      var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
                      var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


                      ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
                      ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

                    var ca = new GameObject("Saint Shalriahair");
                    ca.transform.SetParent(Instance.transform.Find("Head"));
                    ca.transform.localPosition = new Vector3(0, 0f);
                    ca.transform.localScale = new Vector3(1f, 1f);
                    var caSprite = ca.AddComponent<SpriteRenderer>();
                    caSprite.sprite = ModAPI.LoadSprite("image/Saint Shalriahair.png");
                    ca.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
                    ca.AddComponent<UseEventTrigger>().Action = () => {
                    caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                                      };


                    var backpack = new GameObject("Saint Shalriahelmet");
                    backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
                    backpack.transform.localPosition = new Vector3(0, 0f);
                    backpack.transform.localScale = new Vector3(1f, 1f);
                    var backpackSprite = backpack.AddComponent<SpriteRenderer>();
                    backpackSprite.sprite = ModAPI.LoadSprite("image/Saint Shalriahelmet.png");
                    backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
                    backpack.AddComponent<UseEventTrigger>().Action = () => {
                    backpackSprite.sprite = ModAPI.LoadSprite("none.png");

                                                                            };
                    var ca2 = new GameObject("Saint Shalriacape");
                    ca2.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
                    ca2.transform.localPosition = new Vector3(0, 0f);
                    ca2.transform.localScale = new Vector3(1f, 1f);
                    var ca2Sprite = ca2.AddComponent<SpriteRenderer>();
                    ca2Sprite.sprite = ModAPI.LoadSprite("image/Saint Shalriacape.png");
                    ca2.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
                    ca2.AddComponent<UseEventTrigger>().Action = () => {
                    ca2Sprite.sprite = ModAPI.LoadSprite("none.png");
                                                                      };

                                      }
                                  }
                              }
   );

  ModAPI.Register(
      new Modification()
          {
     OriginalItem = ModAPI.FindSpawnable("Human"),
     NameOverride = "Monkey D. Garp",
     NameToOrderByOverride = "Z1",
     DescriptionOverride = "Monkey D. Garp is an extremely famous and powerful Marine vice admiral." + "\n <color=blue>Hero of the Navy ",
     CategoryOverride = ModAPI.FindCategory("One Piece pack"),
     ThumbnailOverride = ModAPI.LoadSprite("image/Monkey D. Garpthumbnail.png"),
     AfterSpawn = (Instance) =>
     {

     var skin = ModAPI.LoadTexture("image/Monkey D. Garp.png");
     var flesh = ModAPI.LoadTexture("Flesh.png");
     var bone = ModAPI.LoadTexture("Bone.png");



     var person = Instance.GetComponent<PersonBehaviour>();

     var head = Instance.transform.Find("Head");
     var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
     var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
     var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
     var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
     var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
     var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
     var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
     var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
     var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
     var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
     var upper = Instance.transform.Find("Body").Find("UpperBody");
     var middle = Instance.transform.Find("Body").Find("MiddleBody");
     var Lower = Instance.transform.Find("Body").Find("LowerBody");

     upper.transform.localScale = new Vector3(1.4f, 1.2f);
     middle.transform.localScale = new Vector3(1.3f, 1.2f);
     Lower.transform.localScale = new Vector3(1.2f, 1f);
     arm3.transform.localScale = new Vector3(1.3f, 1.2f);
     arm4.transform.localScale = new Vector3(1.3f, 1.2f);
     arm1.transform.localScale = new Vector3(1.3f, 1.2f);
     arm2.transform.localScale = new Vector3(1.3f, 1.2f);
     leg3.transform.localScale = new Vector3(1.19f, 1.2f);
     leg4.transform.localScale = new Vector3(1.19f, 1.2f);
     leg1.transform.localScale = new Vector3(1.19f, 1.2f);
     leg2.transform.localScale = new Vector3(1.19f, 1.2f);
     foot1.transform.localScale = new Vector3(1.19f, 1.2f);
     foot2.transform.localScale = new Vector3(1.19f, 1.2f);
     head.transform.localScale = new Vector3(0.7f, 0.7f);

     head.transform.localPosition = new Vector3(0.02f, 0.700f);
     arm3.transform.localPosition = new Vector3(0f, -0.15f);
     arm4.transform.localPosition = new Vector3(0f, -0.15f);
     arm1.transform.localPosition = new Vector3(0f, -0.60f);
     arm2.transform.localPosition = new Vector3(0f, -0.60f);
     leg3.transform.localPosition = new Vector3(0f, -0.46f);
     leg4.transform.localPosition = new Vector3(0f, -0.46f);
     leg1.transform.localPosition = new Vector3(0f, -0.96f);
     leg2.transform.localPosition = new Vector3(0f, -0.96f);
     foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
     foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
     AudioSource Audio = Instance.AddComponent<AudioSource>();
     Audio.maxDistance = 10;
     Audio.loop = false;
     Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

     AudioSource Audio3 = Instance.AddComponent<AudioSource>();
     Audio3.maxDistance = 10;
     Audio3.loop = false;
     Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");


Lower.gameObject.AddComponent<kenbun>();
     arm1.gameObject.AddComponent<ryuo>();
     arm2.gameObject.AddComponent<ryuo>();
     person.SetBodyTextures(skin, flesh, bone, 1);
     foreach (var body in person.Limbs)
      {
         body.BaseStrength *= 0.4f;
         body.Health *= 11000f;
         body.BreakingThreshold *= 1f;
         body.IsAndroid = true;
         body.transform.root.localScale *= 1.02f;
         body.gameObject.AddComponent<strongrege>();

         UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
         useEventTrigger.Event = new UnityEvent();
         useEventTrigger.Event.AddListener(delegate ()
          {
           body.ImmuneToDamage = true;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
           Audio.Play();
         });

         UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
         useEventTrigger1.Event = new UnityEvent();
         useEventTrigger1.Event.AddListener(delegate ()
          {
            body.ImmuneToDamage = false;
            arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
            arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
            arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            Audio.Play();
         });



         UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
         useEventTrigger2.Event = new UnityEvent();
         useEventTrigger2.Event.AddListener(delegate ()
          {
            Audio3.Play();
         });

         var ornamentobject = new GameObject("garphair.png");
         ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
         ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
         ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
         ornamentobject.transform.localScale = new Vector3(1f, 1f);
         var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
         ornamentsprite.sprite = ModAPI.LoadSprite("image/garphair.png",2f);
         ornamentsprite.sortingLayerName = "Middle";

      //cape4
       var backpack = new GameObject("cape4");
       backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
       backpack.transform.localPosition = new Vector3(0, 0f);
       backpack.transform.localScale = new Vector3(1f, 1f);
       var backpackSprite = backpack.AddComponent<SpriteRenderer>();
       backpackSprite.sprite = ModAPI.LoadSprite("image/cape4.png");
       backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
       backpack.AddComponent<UseEventTrigger>().Action = () => {
       backpackSprite.sprite = ModAPI.LoadSprite("none.png");

                                                               };

      person.SetBruiseColor(000, 000, 000);
      person.SetSecondBruiseColor(000, 000, 000);
      person.SetThirdBruiseColor(000, 000, 000);
      person.SetBloodColour(000, 000, 000);
      person.SetRottenColour(000, 000, 000);



             }
          }
       }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Sengoku",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Sengoku the Buddha is a former fleet admiral of the Marines, succeeding Kong and preceding Sakazuki. Sometime during the timeskip, he became an Inspector General.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Sengokuthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Sengoku.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.4f, 1.2f);
   middle.transform.localScale = new Vector3(1.3f, 1.2f);
   Lower.transform.localScale = new Vector3(1.2f, 1f);
   arm3.transform.localScale = new Vector3(1.3f, 1.2f);
   arm4.transform.localScale = new Vector3(1.3f, 1.2f);
   arm1.transform.localScale = new Vector3(1.3f, 1.2f);
   arm2.transform.localScale = new Vector3(1.3f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.02f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

Lower.gameObject.AddComponent<kenbun>();
   head.gameObject.AddComponent<hao>();
   arm1.gameObject.AddComponent<ryuo>();
   arm2.gameObject.AddComponent<ryuo>();


   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
       body.BaseStrength *= 0.4f;
       body.Health *= 11000f;
       body.BreakingThreshold *= 1f;
       body.IsAndroid = true;
       body.transform.root.localScale *= 1.01f;
       body.gameObject.AddComponent<strongrege>();
       UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger0.Event = new UnityEvent();
       useEventTrigger0.Event.AddListener(delegate ()
        {
          ModAPI.CreateParticleEffect("Vapor", head.transform.position);
         Audio2.Play();
       });

       UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger.Event = new UnityEvent();
       useEventTrigger.Event.AddListener(delegate ()
        {
         body.ImmuneToDamage = true;
         arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
         arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
         Audio.Play();
       });

       UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger1.Event = new UnityEvent();
       useEventTrigger1.Event.AddListener(delegate ()
        {
          body.ImmuneToDamage = false;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          Audio.Play();
       });

       UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger2.Event = new UnityEvent();
       useEventTrigger2.Event.AddListener(delegate ()
        {
          Audio3.Play();
       });


         var ca = new GameObject("sengokuhair");
         ca.transform.SetParent(Instance.transform.Find("Head"));
         ca.transform.localPosition = new Vector3(0, 0f);
         ca.transform.localScale = new Vector3(1f, 1f);
         var caSprite = ca.AddComponent<SpriteRenderer>();
         caSprite.sprite = ModAPI.LoadSprite("image/sengokuhair.png");
         ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
         ca.AddComponent<UseEventTrigger>().Action = () => {
         caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                          };

    //cape4
     var backpack = new GameObject("cape4");
     backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
     backpack.transform.localPosition = new Vector3(0, 0f);
     backpack.transform.localScale = new Vector3(1f, 1f);
     var backpackSprite = backpack.AddComponent<SpriteRenderer>();
     backpackSprite.sprite = ModAPI.LoadSprite("image/cape4.png");
     backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
     backpack.AddComponent<UseEventTrigger>().Action = () => {
     backpackSprite.sprite = ModAPI.LoadSprite("none.png");
                                                             };
    person.SetBruiseColor(000, 000, 000);
    person.SetSecondBruiseColor(000, 000, 000);
    person.SetThirdBruiseColor(000, 000, 000);
    person.SetBloodColour(000, 000, 000);
    person.SetRottenColour(000, 000, 000);

           }
        }
     }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Sengoku hybrid form",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Sengoku hybrid form.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Sengoku hybrid formthumb.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Sengoku hybrid form.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");

   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.5f, 1.2f);
   middle.transform.localScale = new Vector3(1.4f, 1.2f);
   Lower.transform.localScale = new Vector3(1.3f, 1.2f);
   arm3.transform.localScale = new Vector3(1.7f, 1.3f);
   arm4.transform.localScale = new Vector3(1.7f, 1.3f);
   arm1.transform.localScale = new Vector3(1.7f, 1.3f);
   arm2.transform.localScale = new Vector3(1.7f, 1.3f);
   leg3.transform.localScale = new Vector3(1.3f, 1f);
   leg4.transform.localScale = new Vector3(1.3f, 1f);

   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.02f, 0.700f);

   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.61f);
   arm2.transform.localPosition = new Vector3(0f, -0.61f);

   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   head.gameObject.AddComponent<hao>();
   Lower.gameObject.AddComponent<kenbun>();
   arm1.gameObject.AddComponent<ryuo>();
   arm2.gameObject.AddComponent<ryuo>();


   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
       body.BaseStrength *= 1f;
       body.Health *= 10000f;
       body.BreakingThreshold *= 100f;
       body.IsAndroid = true;
       body.transform.root.localScale *= 1.106f;
       body.gameObject.AddComponent<strongrege>();
       UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger0.Event = new UnityEvent();
       useEventTrigger0.Event.AddListener(delegate ()
        {
          ModAPI.CreateParticleEffect("Vapor", head.transform.position);
         Audio2.Play();
       });

       UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger.Event = new UnityEvent();
       useEventTrigger.Event.AddListener(delegate ()
        {
         body.ImmuneToDamage = true;
         arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
         arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
         Audio.Play();
       });

       UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger1.Event = new UnityEvent();
       useEventTrigger1.Event.AddListener(delegate ()
        {
          body.ImmuneToDamage = false;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          Audio.Play();
       });

       UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger2.Event = new UnityEvent();
       useEventTrigger2.Event.AddListener(delegate ()
        {
          Audio3.Play();
       });

         var ca = new GameObject("Sengoku hybrid formhair");
         ca.transform.SetParent(Instance.transform.Find("Head"));
         ca.transform.localPosition = new Vector3(0, 0f);
         ca.transform.localScale = new Vector3(1f, 1f);
         var caSprite = ca.AddComponent<SpriteRenderer>();
         caSprite.sprite = ModAPI.LoadSprite("image/Sengoku hybrid formhair.png");
         ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
         ca.AddComponent<UseEventTrigger>().Action = () => {
         caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                          };

    //cape4
     var backpack = new GameObject("Sengoku hybrid formcape");
     backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
     backpack.transform.localPosition = new Vector3(0, 0f);
     backpack.transform.localScale = new Vector3(1f, 1f);
     var backpackSprite = backpack.AddComponent<SpriteRenderer>();
     backpackSprite.sprite = ModAPI.LoadSprite("image/Sengoku hybrid formcape.png");
     backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
     backpack.AddComponent<UseEventTrigger>().Action = () => {
     backpackSprite.sprite = ModAPI.LoadSprite("none.png");
                                                             };

    person.SetBruiseColor(000, 000, 000);
    person.SetSecondBruiseColor(000, 000, 000);
    person.SetThirdBruiseColor(000, 000, 000);
    person.SetBloodColour(000, 000, 000);
    person.SetRottenColour(000, 000, 000);

           }
        }
     }
);

ModAPI.Register(
new Modification()
{
    OriginalItem = ModAPI.FindSpawnable("Human"), //item to derive from
    NameOverride = "Edward Newgate Old", //new item name with a suffix to assure it is globally unique
    NameToOrderByOverride = "Z1",
    DescriptionOverride = "Edward Newgate more commonly known as Whitebeard was the captain of the Whitebeard Pirates Old shape.", //new item description
    CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
    ThumbnailOverride = ModAPI.LoadSprite("image/Edward Newgate Oldthumbnnail.png"), //new item thumbnail (relative path)
    AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
    {
        //load textures for each layer (see Human textures folder in this repository)
        var skin = ModAPI.LoadTexture("image/Edward Newgate old.png");
        var flesh = ModAPI.LoadTexture("Flesh.png");
        var bone = ModAPI.LoadTexture("Bone.png");

        var person = Instance.GetComponent<PersonBehaviour>();

        var head = Instance.transform.Find("Head");
        var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
        var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
        var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
        var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
        var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
        var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
        var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
        var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
        var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
        var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
        var upper = Instance.transform.Find("Body").Find("UpperBody");
        var middle = Instance.transform.Find("Body").Find("MiddleBody");
        var Lower = Instance.transform.Find("Body").Find("LowerBody");

        upper.transform.localScale = new Vector3(1.4f, 1.2f);
        middle.transform.localScale = new Vector3(1.3f, 1.2f);
        Lower.transform.localScale = new Vector3(1.2f, 1f);
        arm3.transform.localScale = new Vector3(1.3f, 1.2f);
        arm4.transform.localScale = new Vector3(1.3f, 1.2f);
        arm1.transform.localScale = new Vector3(1.3f, 1.2f);
        arm2.transform.localScale = new Vector3(1.3f, 1.2f);
        leg3.transform.localScale = new Vector3(1.43f, 1.2f);
        leg4.transform.localScale = new Vector3(1.43f, 1.2f);
        leg1.transform.localScale = new Vector3(1.19f, 1.2f);
        leg2.transform.localScale = new Vector3(1.19f, 1.2f);
        foot1.transform.localScale = new Vector3(1.19f, 1.2f);
        foot2.transform.localScale = new Vector3(1.19f, 1.2f);
        head.transform.localScale = new Vector3(0.7f, 0.7f);

        head.transform.localPosition = new Vector3(0.02f, 0.700f);
        leg3.transform.localPosition = new Vector3(0f, -0.46f);
        leg4.transform.localPosition = new Vector3(0f, -0.46f);
        leg1.transform.localPosition = new Vector3(0f, -0.96f);
        leg2.transform.localPosition = new Vector3(0f, -0.96f);
        foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
        foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);

        arm3.transform.localPosition = new Vector3(0f, -0.15f);
        arm4.transform.localPosition = new Vector3(0f, -0.15f);
        arm1.transform.localPosition = new Vector3(0f, -0.60f);
        arm2.transform.localPosition = new Vector3(0f, -0.60f);

        AudioSource Audio2 = Instance.AddComponent<AudioSource>();
        Audio2.maxDistance = 10;
        Audio2.loop = false;
        Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

        AudioClip Repulsor = ModAPI.LoadSound("Sound/guragurarug.mp3");
        AudioClip beam2 = ModAPI.LoadSound("Sound/guragurarug.mp3");


        head.gameObject.AddComponent<hao>();
        arm1.gameObject.AddComponent<ryuo>();
        arm2.gameObject.AddComponent<ryuo>();
        arm1.gameObject.AddComponent<guraguranomi>();
        arm2.gameObject.AddComponent<guraguranomi>();
        leg1.gameObject.AddComponent<Busoshoku>();
        leg2.gameObject.AddComponent<Busoshoku>();

        foreach (var Limbs in person.Limbs)
        {;

            if (Limbs.GetComponent<GripBehaviour>())
            {
                Limbs.gameObject.AddComponent<UseEventTrigger>().Action = () =>
                {


                    AudioSource audio = Limbs.gameObject.AddComponent<AudioSource>();
                    audio.spatialBlend = 1;
                    audio.PlayOneShot(Repulsor);
                };
            }
        }


        foreach (var body in person.Limbs)
        {
          body.BaseStrength *= 1f;
          body.Health *= 666f;
          body.Wince(0f);
          body.DoStumble = true;
          body.DoBalanceJerk = true;
          body.IsAndroid = true;
          body.transform.root.localScale *= 1.09f;
          body.PhysicalBehaviour.BurningProgressionMultiplier = -100;
          body.gameObject.AddComponent<strongrege>();
          UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
          useEventTrigger0.Event = new UnityEvent();
          useEventTrigger0.Event.AddListener(delegate ()
           {
             ModAPI.CreateParticleEffect("Vapor", head.transform.position);
            Audio2.Play();
          });


      //Edward Newgate old1.png
        var ca = new GameObject("Edward Newgate old1.png");
        ca.transform.SetParent(Instance.transform.Find("Head"));
        ca.transform.localPosition = new Vector3(0, 0f);
        ca.transform.localScale = new Vector3(1f, 1f);
        var caSprite = ca.AddComponent<SpriteRenderer>();
        caSprite.sprite = ModAPI.LoadSprite("image/Edward Newgate old1.png");
        ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
        ca.AddComponent<UseEventTrigger>().Action = () => {
        caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                          };

      //cape2
       var backpack = new GameObject("cape2");
       backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
       backpack.transform.localPosition = new Vector3(0, 0f);
       backpack.transform.localScale = new Vector3(1f, 1f);
       var backpackSprite = backpack.AddComponent<SpriteRenderer>();
       backpackSprite.sprite = ModAPI.LoadSprite("image/cape2.png");
       backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
       backpack.AddComponent<UseEventTrigger>().Action = () => {
       backpackSprite.sprite = ModAPI.LoadSprite("none.png");

      };

        }
        person.SetBodyTextures(skin, flesh, bone, 1);
        person.SetBruiseColor(108, 0, 4); //main bruise colour. purple-ish by default
        person.SetSecondBruiseColor(108, 0, 4); //second bruise colour. red by default
        person.SetThirdBruiseColor(108, 0, 4); // third bruise colour. light yellow by default
        person.SetBloodColour(108, 0, 4); // blood clour. dark red by default
        person.SetRottenColour(0, 0, 0); // rotten/zombie colour. light yellow/green by default
    }
}
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = ""+"\n <color=yellow>Shiki",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = ""+"\n <color=white>Shiki the Golden Lion, also known as the Flying Pirate, is the admiral of the Golden Lion Pirates, the first known prisoner ever to escape from Impel Down and a former member of the Rocks Pirates." + "\n <color=yellow>Golden Lion",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Shikithumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Shiki.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var leg1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.4f, 1.2f);
   middle.transform.localScale = new Vector3(1.4f, 1.2f);
   Lower.transform.localScale = new Vector3(1.4f, 1.2f);
   arm3.transform.localScale = new Vector3(1.15f, 1.1f);
   arm4.transform.localScale = new Vector3(1.14f, 1.1f);
   arm1.transform.localScale = new Vector3(1.14f, 1.1f);
   arm2.transform.localScale = new Vector3(1.14f, 1.1f);
   leg3.transform.localScale = new Vector3(1.2f, 1f);
   leg4.transform.localScale = new Vector3(1.2f, 1f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);

   arm3.transform.localPosition = new Vector3(0f, -0.12f);
   arm4.transform.localPosition = new Vector3(0f, -0.12f);
   arm1.transform.localPosition = new Vector3(0f, -0.54f);
   arm2.transform.localPosition = new Vector3(0f, -0.54f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   Lower.gameObject.AddComponent<kenbun>();
   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();
   arm1.gameObject.AddComponent<Antigravity>();
   arm2.gameObject.AddComponent<Antigravity>();



   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
       body.BaseStrength *= 0.3f;
       body.Health *= 10000000f;
       body.BreakingThreshold *= 100f;
       body.IsAndroid = true;
       body.transform.root.localScale *= 1.03f;
       body.PhysicalBehaviour.BurningProgressionMultiplier = -10000000;
       body.gameObject.AddComponent<strongrege>();
       UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger.Event = new UnityEvent();
       useEventTrigger.Event.AddListener(delegate ()
        {
         body.ImmuneToDamage = true;
         arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
         arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
         Audio.Play();
       });

       UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger1.Event = new UnityEvent();
       useEventTrigger1.Event.AddListener(delegate ()
        {
          body.ImmuneToDamage = false;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          Audio.Play();
       });

       UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger2.Event = new UnityEvent();
       useEventTrigger2.Event.AddListener(delegate ()
        {
          Audio3.Play();
       });

     var ornamentobject = new GameObject("Shikihair.png");
     ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
     ornamentobject.transform.localPosition = new Vector3(-0.03f, -0.3f);
     ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
     ornamentobject.transform.localScale = new Vector3(1f, 1f);
     var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
     ornamentsprite.sprite = ModAPI.LoadSprite("image/Shikihair.png",2f);
     ornamentsprite.sortingLayerName = "Middle";

       var ca = new GameObject("Shikicape.png");
       ca.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
       ca.transform.localPosition = new Vector3(0, 0f);
       ca.transform.localScale = new Vector3(1f, 1f);
       var caSprite = ca.AddComponent<SpriteRenderer>();
       caSprite.sprite = ModAPI.LoadSprite("image/Shikicape.png");
       ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
       ca.AddComponent<UseEventTrigger>().Action = () => {
       caSprite.sprite = ModAPI.LoadSprite("none.png");
       };

       var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
       var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


       ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
       ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";


      person.SetBruiseColor(000, 000, 000);
      person.SetSecondBruiseColor(000, 000, 000);
      person.SetThirdBruiseColor(000, 000, 000);
      person.SetBloodColour(000, 000, 000);
      person.SetRottenColour(000, 000, 000);

           }
        }
     }
 );

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Byrnndi World",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Byrnndi World is a powerful pirate who caused havoc on the seas over 30 years ago and is the captain of the World Pirates He also is Byojack's younger brother.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/ByrnndiWorldthumb.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Byrnndi World.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");
   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var leg1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.5f, 1.2f);
   middle.transform.localScale = new Vector3(1.4f, 1.2f);
   Lower.transform.localScale = new Vector3(1.3f, 1.2f);
   arm3.transform.localScale = new Vector3(1.7f, 1.2513f);
   arm4.transform.localScale = new Vector3(1.7f, 1.2513f);
   arm1.transform.localScale = new Vector3(1.7f, 1.3f);
   arm2.transform.localScale = new Vector3(1.7f, 1.3f);
   leg3.transform.localScale = new Vector3(1.3f, 1f);
   leg4.transform.localScale = new Vector3(1.3f, 1f);

   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.02f, 0.700f);

   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.61f);
   arm2.transform.localPosition = new Vector3(0f, -0.61f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   Lower.gameObject.AddComponent<kenbun>();
   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();

   var person = Instance.GetComponent<PersonBehaviour>();
   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 1f;
        body.Health *= 100f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1.04f;
        body.gameObject.AddComponent<strongrege>();
        UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });

        UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger2.Event = new UnityEvent();
        useEventTrigger2.Event.AddListener(delegate ()
         {
           Audio3.Play();
        });


        var ca = new GameObject("ByrnndiWorldhat");
        ca.transform.SetParent(Instance.transform.Find("Head"));
        ca.transform.localPosition = new Vector3(0, 0f);
        ca.transform.localScale = new Vector3(1f, 1f);
        var caSprite = ca.AddComponent<SpriteRenderer>();
        caSprite.sprite = ModAPI.LoadSprite("image/ByrnndiWorldhat.png");
        ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        ca.AddComponent<UseEventTrigger>().Action = () => {
        caSprite.sprite = ModAPI.LoadSprite("none.png");
        };

        var ca2 = new GameObject("ByrnndiWorldhair");
        ca2.transform.SetParent(Instance.transform.Find("Head"));
        ca2.transform.localPosition = new Vector3(0, 0f);
        ca2.transform.localScale = new Vector3(1f, 1f);
        var ca2Sprite = ca2.AddComponent<SpriteRenderer>();
        ca2Sprite.sprite = ModAPI.LoadSprite("image/ByrnndiWorldhair.png");
        ca2.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        ca2.AddComponent<UseEventTrigger>().Action = () => {
        ca2Sprite.sprite = ModAPI.LoadSprite("none.png");
        };

        var ca3 = new GameObject("ByrnndiWorldcape");
        ca3.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
        ca3.transform.localPosition = new Vector3(0, 0f);
        ca3.transform.localScale = new Vector3(1f, 1f);
        var ca3Sprite = ca3.AddComponent<SpriteRenderer>();
        ca3Sprite.sprite = ModAPI.LoadSprite("image/ByrnndiWorldcape.png");
        ca3.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
        ca3.AddComponent<UseEventTrigger>().Action = () => {
        ca3Sprite.sprite = ModAPI.LoadSprite("none.png");
      };
      var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
      var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


      ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Gild Tesoro",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Gild Tesoro,also known as the Casino King, was the proprietor of Gran Tesoro, the largest entertainment city-ship in the world, before his defeat by the Straw Hat Pirates and arrest by the Marines.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/GildTesorothumb.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Gild Tesoro.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");
   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.2f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();
   leg1.gameObject.AddComponent<Busoshoku>();
   leg2.gameObject.AddComponent<Busoshoku>();

   var person = Instance.GetComponent<PersonBehaviour>();
   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.3f;
        body.Health *= 100f;
        body.BreakingThreshold *= 1f;
        body.transform.root.localScale *= 1.02f;
        body.IsAndroid = true;
        body.gameObject.AddComponent<strongrege>();
        UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(255f, 255f, 0f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(255f, 255f, 0f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });

        var ca = new GameObject("GildTesorohair");
        ca.transform.SetParent(Instance.transform.Find("Head"));
        ca.transform.localPosition = new Vector3(0, 0f);
        ca.transform.localScale = new Vector3(1f, 1f);
        var caSprite = ca.AddComponent<SpriteRenderer>();
        caSprite.sprite = ModAPI.LoadSprite("image/GildTesorohair.png");
        ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
        ca.AddComponent<UseEventTrigger>().Action = () => {
        caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                           };

        var ca2 = new GameObject("GildTesoroflower");
        ca2.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
        ca2.transform.localPosition = new Vector3(0, 0f);
        ca2.transform.localScale = new Vector3(1f, 1f);
        var ca2Sprite = ca2.AddComponent<SpriteRenderer>();
        ca2Sprite.sprite = ModAPI.LoadSprite("image/GildTesoroflower.png");
        ca2.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
        ca2.AddComponent<UseEventTrigger>().Action = () => {
        ca2Sprite.sprite = ModAPI.LoadSprite("none.png");
                                                           };


                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Douglas Bullet",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Douglas Bullet, known as the Demon Heir,After serving as a child soldier in his homeland of Galzburg, he joined the Roger Pirates and was later imprisoned in Impel Down for over 20 years.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/DouglasBulletthumb.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Douglas Bullet.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");
   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var leg1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.5f, 1.2f);
   middle.transform.localScale = new Vector3(1.4f, 1.2f);
   Lower.transform.localScale = new Vector3(1.3f, 1.2f);
   arm3.transform.localScale = new Vector3(1.7f, 1.3f);
   arm4.transform.localScale = new Vector3(1.7f, 1.3f);
   arm1.transform.localScale = new Vector3(1.7f, 1.3f);
   arm2.transform.localScale = new Vector3(1.7f, 1.3f);
   leg3.transform.localScale = new Vector3(1.3f, 1f);
   leg4.transform.localScale = new Vector3(1.3f, 1f);

   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.02f, 0.700f);

   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.61f);
   arm2.transform.localPosition = new Vector3(0f, -0.61f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   head.gameObject.AddComponent<hao>();
   Lower.gameObject.AddComponent<kenbun>();
   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();

   var person = Instance.GetComponent<PersonBehaviour>();
   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 1f;
        body.Health *= 1000f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1.04f;
        body.gameObject.AddComponent<strongrege>();
        UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger0.Event = new UnityEvent();
        useEventTrigger0.Event.AddListener(delegate ()
         {
           ModAPI.CreateParticleEffect("Vapor", head.transform.position);
          Audio2.Play();
        });

        UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });

        UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger2.Event = new UnityEvent();
        useEventTrigger2.Event.AddListener(delegate ()
         {
           Audio3.Play();
        });


        var ca = new GameObject("DouglasBullethair");
        ca.transform.SetParent(Instance.transform.Find("Head"));
        ca.transform.localPosition = new Vector3(0, 0f);
        ca.transform.localScale = new Vector3(1f, 1f);
        var caSprite = ca.AddComponent<SpriteRenderer>();
        caSprite.sprite = ModAPI.LoadSprite("image/DouglasBullethair.png");
        ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
        ca.AddComponent<UseEventTrigger>().Action = () => {
        caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                          };


                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Zephyr",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Z, also known by his birth name and former epithet Black Arm Zephyr, was the leader and founder of the Neo Marines as well as a former Marine Admiral and instructor before his resignation.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Zephyrthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Zephyr.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.4f, 1.2f);
   middle.transform.localScale = new Vector3(1.3f, 1.2f);
   Lower.transform.localScale = new Vector3(1.2f, 1f);
   arm3.transform.localScale = new Vector3(2.3f, 1.7f);
   arm4.transform.localScale = new Vector3(1.3f, 1.2f);
   arm1.transform.localScale = new Vector3(3.2f, 2.5f);
   arm2.transform.localScale = new Vector3(1.3f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.02f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.23f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -1.05f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);

   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   Lower.gameObject.AddComponent<kenbun>();
   arm2.gameObject.AddComponent<Busoshoku>();
   arm1.gameObject.AddComponent<ryuo>();

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
       body.BaseStrength *= 0.5f;
       body.Health *= 100f;
       body.BreakingThreshold *= 100f;
       body.IsAndroid = true;
       body.transform.root.localScale *= 1.03f;
       arm3.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Metal");
       arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Metal");
       body.gameObject.AddComponent<strongrege>();
       if (body.GetComponent<GripBehaviour>() && body.gameObject.name == "LowerArmFront")
       {
           body.gameObject.AddComponent<UseEventTrigger>().Action = () =>
           {
               GameObject HandOBJ2 = UnityEngine.Object.Instantiate(ModAPI.FindSpawnable("Detached Laser Cannon").Prefab.GetComponent<BlasterBehaviour>().Bolt);
               HandOBJ2.GetComponent<BlasterboltBehaviour>().Trail.startColor = new Color(255, 255, 0);
               HandOBJ2.GetComponent<BlasterboltBehaviour>().Trail.endColor = new Color(255, 255, 0);

               ModAPI.CreateParticleEffect("Vapor", new Vector2(arm1.transform.position.x, arm1.transform.position.y + 0.1f));
               HandOBJ2.transform.position = body.gameObject.transform.position;
               HandOBJ2.transform.eulerAngles = body.gameObject.transform.eulerAngles;
               HandOBJ2.transform.eulerAngles += new Vector3(0, 0, 270);

           };
       }

       var Hand = new GameObject("Hand");
       Hand.transform.SetParent(Instance.transform.Find("BackArm").Find("UpperArm"));
       Hand.transform.localPosition = new Vector3(0, 0f);
       Hand.transform.localScale = new Vector3(1f, 1f);
       var HandSprite = Hand.AddComponent<SpriteRenderer>();
       HandSprite.sprite = ModAPI.LoadSprite("image/Zephyrarm2.png");
       HandSprite.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";

       var Up = new GameObject("Up");
       Up.transform.SetParent(Instance.transform.Find("BackArm").Find("LowerArm"));
       Up.transform.localPosition = new Vector3(0, 0f);
       Up.transform.localScale = new Vector3(1f, 1f);
       var UpSprite = Up.AddComponent<SpriteRenderer>();
       UpSprite.sprite = ModAPI.LoadSprite("image/Zephyrarm1.png");
       Up.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";

       UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger.Event = new UnityEvent();
       useEventTrigger.Event.AddListener(delegate ()
        {
         arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         Audio.Play();
       });

       UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger1.Event = new UnityEvent();
       useEventTrigger1.Event.AddListener(delegate ()
        {
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          Audio.Play();
       });


       UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger2.Event = new UnityEvent();
       useEventTrigger2.Event.AddListener(delegate ()
        {
          Audio3.Play();
       });

       var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
       var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");

       ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
       ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

       var ornamentobject = new GameObject("Zephyrhair.png");
       ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
       ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
       ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
       ornamentobject.transform.localScale = new Vector3(1f, 1f);
       var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
       ornamentsprite.sprite = ModAPI.LoadSprite("image/Zephyrhair.png",2f);
       ornamentsprite.sortingLayerName = "Top";



     var ca2 = new GameObject("Zephyrcape.png");
     ca2.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
     ca2.transform.localPosition = new Vector3(0, 0f);
     ca2.transform.localScale = new Vector3(1f, 1f);
     var ca2Sprite = ca2.AddComponent<SpriteRenderer>();
     ca2Sprite.sprite = ModAPI.LoadSprite("image/Zephyrcape.png");
     ca2.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
     ca2.AddComponent<UseEventTrigger>().Action = () => {
     ca2Sprite.sprite = ModAPI.LoadSprite("none.png");
                                                         };

     person.SetBruiseColor(000, 000, 000);
     person.SetSecondBruiseColor(000, 000, 000);
     person.SetThirdBruiseColor(000, 000, 000);
     person.SetBloodColour(000, 000, 000);
     person.SetRottenColour(000, 000, 000);

           }
        }
     }
   );

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = ""+"\n <color=green>Monkey D. Dragon",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = ""+"\n <color=white>Monkey D. Dragon, commonly known as the World's Worst Criminal, is the infamous Supreme Commander of the Revolutionary Army who has been attempting to overthrow the World Government." + "\n <color=green>World's Worst Criminal ",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Monkey D. Dragonthumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Monkey D. Dragon.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");



   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.4f, 1.2f);
   middle.transform.localScale = new Vector3(1.3f, 1.2f);
   Lower.transform.localScale = new Vector3(1.2f, 1f);
   arm3.transform.localScale = new Vector3(1.3f, 1.2f);
   arm4.transform.localScale = new Vector3(1.3f, 1.2f);
   arm1.transform.localScale = new Vector3(1.3f, 1.2f);
   arm2.transform.localScale = new Vector3(1.3f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   head.gameObject.AddComponent<hao>();
   Lower.gameObject.AddComponent<kenbun>();
   arm1.gameObject.AddComponent<dragonpower>();
   arm2.gameObject.AddComponent<dragonpower>();
   arm1.gameObject.AddComponent<ryuo>();
   arm2.gameObject.AddComponent<ryuo>();
   leg1.gameObject.AddComponent<Busoshoku>();
   leg2.gameObject.AddComponent<Busoshoku>();

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
       body.BaseStrength *= 0.4f;
       body.Health *= 11000f;
       body.BreakingThreshold *= 1f;
       body.IsAndroid = true;
       body.transform.root.localScale *= 1.01f;
       body.gameObject.AddComponent<strongrege>();

       UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger0.Event = new UnityEvent();
       useEventTrigger0.Event.AddListener(delegate ()
        {
          ModAPI.CreateParticleEffect("Vapor", head.transform.position);
         Audio2.Play();
       });

       UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger.Event = new UnityEvent();
       useEventTrigger.Event.AddListener(delegate ()
        {
         body.ImmuneToDamage = true;
         arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
         arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
         arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
         Audio.Play();
       });

       UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger1.Event = new UnityEvent();
       useEventTrigger1.Event.AddListener(delegate ()
        {
          body.ImmuneToDamage = false;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          Audio.Play();
       });

       UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger2.Event = new UnityEvent();
       useEventTrigger2.Event.AddListener(delegate ()
        {
          Audio3.Play();
       });


       var ornamentobject = new GameObject("dragonhair.png");
       ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
       ornamentobject.transform.localPosition = new Vector3(-0.03f, -0.3f);
       ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
       ornamentobject.transform.localScale = new Vector3(1f, 1f);
       var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
       ornamentsprite.sprite = ModAPI.LoadSprite("image/dragonhair.png",2f);
       ornamentsprite.sortingLayerName = "Middle";

    //cape19
     var backpack = new GameObject("cape19");
     backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
     backpack.transform.localPosition = new Vector3(0, 0f);
     backpack.transform.localScale = new Vector3(1f, 1f);
     var backpackSprite = backpack.AddComponent<SpriteRenderer>();
     backpackSprite.sprite = ModAPI.LoadSprite("image/cape19.png");
     backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
     backpack.AddComponent<UseEventTrigger>().Action = () => {
     backpackSprite.sprite = ModAPI.LoadSprite("none.png");

                                                             };

    person.SetBruiseColor(000, 000, 000);
    person.SetSecondBruiseColor(000, 000, 000);
    person.SetThirdBruiseColor(000, 000, 000);
    person.SetBloodColour(000, 000, 000);
    person.SetRottenColour(000, 000, 000);



           }
        }
     }
  );

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Portgas D. Ace",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "nicknamed Fire Fist Ace, was the sworn older brother of Luffy and Sabo, and the biological son of the late Pirate King, Gol D. Roger.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Portgas D. Acethunbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Portgas D. Ace.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");

   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.2f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 1;
   Audio.loop = true;
   Audio.clip = ModAPI.LoadSound("Sound/acethem.mp3");

   AudioSource Audio2 = Instance.AddComponent<AudioSource>();
   Audio2.maxDistance = 10;
   Audio2.loop = false;
   Audio2.clip = ModAPI.LoadSound("Sound/haohaki.mp3");

   head.gameObject.AddComponent<hao>();
   arm1.gameObject.AddComponent<Firebeh>();
   arm2.gameObject.AddComponent<Firebeh>();
   arm1.gameObject.AddComponent<Firebeh2>();
   arm2.gameObject.AddComponent<Firebeh2>();

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.3f;
        body.Health *= 100f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1f;
        body.gameObject.GetComponent<PhysicalBehaviour>().Temperature = 36f;
        body.gameObject.AddComponent<regenstuffnthing>();
        UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger0.Event = new UnityEvent();
        useEventTrigger0.Event.AddListener(delegate ()
         {
           ModAPI.CreateParticleEffect("Vapor", head.transform.position);
          Audio2.Play();
        });

        UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = true;
           body.gameObject.GetComponent<PhysicalBehaviour>().Temperature = 200f;
           body.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 0.3f, 0f, 1f);
           head.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 0.3f, 0f, 1f);
           Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = middle.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           body.SkinMaterialHandler.ClearAllDamage();
           body.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           upper.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Stop();
        });


    //Ahat
      var ca = new GameObject("Ahat");
      ca.transform.SetParent(Instance.transform.Find("Head"));
      ca.transform.localPosition = new Vector3(0, 0f);
      ca.transform.localScale = new Vector3(1f, 1f);
      var caSprite = ca.AddComponent<SpriteRenderer>();
      caSprite.sprite = ModAPI.LoadSprite("image/Ahat.png");
      ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ca.AddComponent<UseEventTrigger>().Action = () => {
      caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                         };

      var ornamentobject = new GameObject("acehair.png");
      ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
      ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
      ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
      ornamentobject.transform.localScale = new Vector3(1f, 1f);
      var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
      ornamentsprite.sprite = ModAPI.LoadSprite("image/acehair.png",2f);
      ornamentsprite.sortingLayerName = "Middle";


      var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
      var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


      ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";


      person.SetBodyTextures(skin, flesh, bone, 1);
      person.SetBruiseColor(255, 153, 000);
      person.SetSecondBruiseColor(255, 051, 0000);
      person.SetThirdBruiseColor(255, 000, 000);
      person.SetBloodColour(255, 102, 000);
      person.SetRottenColour(000, 000, 000);

                        }
                    }
                }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Sabo",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = "Sabo is the Revolutionary Army's chief of staff, recognized as the No. 2 of the entire organization outranked only by Supreme Commander Monkey D. Dragon.",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Sabothumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Sabo.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");

   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.2f, 1.2f);
   middle.transform.localScale = new Vector3(1.1f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);
   arm3.transform.localScale = new Vector3(1.18f, 1.2f);
   arm4.transform.localScale = new Vector3(1.18f, 1.2f);
   arm1.transform.localScale = new Vector3(1.18f, 1.2f);
   arm2.transform.localScale = new Vector3(1.18f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);

   head.transform.localPosition = new Vector3(0.01f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 10;
   Audio.loop = false;
   Audio.clip = ModAPI.LoadSound("Sound/haki sound.mp3");

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   arm1.gameObject.AddComponent<Firebeh>();
   arm2.gameObject.AddComponent<Firebeh>();
   Lower.gameObject.AddComponent<kenbun>();

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
        body.BaseStrength *= 0.3f;
        body.Health *= 1000f;
        body.BreakingThreshold *= 1f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1.01f;
        body.PhysicalBehaviour.BurningProgressionMultiplier = -1000000;
        body.gameObject.AddComponent<strongrege>();
        UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
          body.ImmuneToDamage = true;
          arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("AndroidArmour");
          arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0.1f, 0.1f, 0.1f, 1f);
          Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           arm1.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm2.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           arm1.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           arm2.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });

        UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger2.Event = new UnityEvent();
        useEventTrigger2.Event.AddListener(delegate ()
         {
           Audio3.Play();
        });

    //Sabohat
      var ca = new GameObject("Sabohat");
      ca.transform.SetParent(Instance.transform.Find("Head"));
      ca.transform.localPosition = new Vector3(0, 0f);
      ca.transform.localScale = new Vector3(1f, 1f);
      var caSprite = ca.AddComponent<SpriteRenderer>();
      caSprite.sprite = ModAPI.LoadSprite("image/Sabohat.png");
      ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ca.AddComponent<UseEventTrigger>().Action = () => {
      caSprite.sprite = ModAPI.LoadSprite("none.png");
      };

      var ca2 = new GameObject("Sabocape.png");
      ca2.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
      ca2.transform.localPosition = new Vector3(0, 0f);
      ca2.transform.localScale = new Vector3(1f, 1f);
      var ca2Sprite = ca2.AddComponent<SpriteRenderer>();
      ca2Sprite.sprite = ModAPI.LoadSprite("image/Sabocape.png");
      ca2.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ca2.AddComponent<UseEventTrigger>().Action = () => {
      ca2Sprite.sprite = ModAPI.LoadSprite("none.png");
      };

      var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
      var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


      ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";




      person.SetBodyTextures(skin, flesh, bone, 1);
      person.SetBruiseColor(255, 153, 000); //main bruise colour. purple-ish by default
      person.SetSecondBruiseColor(255, 051, 0000); //second bruise colour. red by default
      person.SetThirdBruiseColor(255, 000, 000); // third bruise colour. light yellow by default
      person.SetBloodColour(255, 102, 000); // blood clour. dark red by default
      person.SetRottenColour(000, 000, 000); // rotten/zombie colour. light yellow/green by default




                        }
                    }
                }
);
ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Issho",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = ""+"\n <color=white>Issho, better known by his alias Fujitora, is an admiral in the Marines." + "\n <color=purple>Fujitora",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Isshothumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Issho.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.4f, 1.2f);
   middle.transform.localScale = new Vector3(1.3f, 1.2f);
   Lower.transform.localScale = new Vector3(1.2f, 1f);
   arm3.transform.localScale = new Vector3(1.3f, 1.2f);
   arm4.transform.localScale = new Vector3(1.3f, 1.2f);
   arm1.transform.localScale = new Vector3(1.3f, 1.2f);
   arm2.transform.localScale = new Vector3(1.3f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.02f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   Lower.gameObject.AddComponent<kenbun>();
   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
       body.BaseStrength *= 0.5f;
       body.Health *= 10000000f;
       body.BreakingThreshold *= 100f;
       body.IsAndroid = true;
       body.transform.root.localScale *= 1.02f;
       body.PhysicalBehaviour.BurningProgressionMultiplier = -1000000;
       body.gameObject.AddComponent<strongrege>();

       UseEventTrigger useEventTrigger1 = Lower.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger1.Event = new UnityEvent();
       useEventTrigger1.Event.AddListener(delegate ()
        {
         Audio3.Play();
       });

       var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
       var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


       ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
       ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";



     //scarf2
       var ca = new GameObject("scarf2");
       ca.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
       ca.transform.localPosition = new Vector3(0, 0f);
       ca.transform.localScale = new Vector3(1f, 1f);
       var caSprite = ca.AddComponent<SpriteRenderer>();
       caSprite.sprite = ModAPI.LoadSprite("image/scarf2.png");
       ca.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
       ca.AddComponent<UseEventTrigger>().Action = () => {
       caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                          };

    //cape17
     var backpack = new GameObject("cape17");
     backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
     backpack.transform.localPosition = new Vector3(0, 0f);
     backpack.transform.localScale = new Vector3(1f, 1f);
     var backpackSprite = backpack.AddComponent<SpriteRenderer>();
     backpackSprite.sprite = ModAPI.LoadSprite("image/cape17.png");
     backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
     backpack.AddComponent<UseEventTrigger>().Action = () => {
     backpackSprite.sprite = ModAPI.LoadSprite("none.png");

                                                              };

      person.SetBruiseColor(000, 000, 000);
      person.SetSecondBruiseColor(000, 000, 000);
      person.SetThirdBruiseColor(000, 000, 000);
      person.SetBloodColour(000, 000, 000);
      person.SetRottenColour(000, 000, 000);

           }
        }
     }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Aramaki",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = ""+"\n <color=white>Aramaki, better known by his alias Ryokugyu, is an admiral in the Marines. He attained his rank during the two-year timeskip, along with Fujitora, both filling the two admiral vacancies left by Aokiji and Akainu." + "\n <color=green>Ryokugyu",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Aramakithumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Aramaki.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.4f, 1.2f);
   middle.transform.localScale = new Vector3(1.3f, 1.2f);
   Lower.transform.localScale = new Vector3(1.2f, 1f);
   arm3.transform.localScale = new Vector3(1.3f, 1.2f);
   arm4.transform.localScale = new Vector3(1.3f, 1.2f);
   arm1.transform.localScale = new Vector3(1.3f, 1.2f);
   arm2.transform.localScale = new Vector3(1.3f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.02f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();
   Lower.gameObject.AddComponent<kenbun>();

   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
       body.BaseStrength *= 0.5f;
       body.Health *= 10000000f;
       body.BreakingThreshold *= 100f;
       body.IsAndroid = true;
       body.transform.root.localScale *= 1.02f;
       body.PhysicalBehaviour.BurningProgressionMultiplier = -1000000;
       body.gameObject.AddComponent<strongrege>();


       var Hand = new GameObject("Hand");
       Hand.transform.SetParent(Instance.transform.Find("BackLeg").Find("UpperLeg"));
       Hand.transform.localPosition = new Vector3(0, 0f);
       Hand.transform.localScale = new Vector3(1f, 1f);
       var HandSprite = Hand.AddComponent<SpriteRenderer>();
       HandSprite.sprite = ModAPI.LoadSprite("image/Aramakileg1.png");
       HandSprite.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";

       var Up = new GameObject("Up");
       Up.transform.SetParent(Instance.transform.Find("BackLeg").Find("LowerLeg"));
       Up.transform.localPosition = new Vector3(0, 0f);
       Up.transform.localScale = new Vector3(1f, 1f);
       var UpSprite = Up.AddComponent<SpriteRenderer>();
       UpSprite.sprite = ModAPI.LoadSprite("image/Aramakileg2.png");
       Up.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";

       var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
       var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


       ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
       ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

       var ornamentobject = new GameObject("Aramakihair.png");
       ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
       ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
       ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
       ornamentobject.transform.localScale = new Vector3(1f, 1f);
       var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
       ornamentsprite.sprite = ModAPI.LoadSprite("image/Aramakihair.png",2.5f);
       ornamentsprite.sortingLayerName = "Middle";

       var ornamentobject3 = new GameObject("Aramakihair2.png");
       ornamentobject3.transform.SetParent(Instance.transform.Find("Head"));
       ornamentobject3.transform.localPosition = new Vector3(-0.03f, 0.03f);
       ornamentobject3.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
       ornamentobject3.transform.localScale = new Vector3(1f, 1f);
       var ornamentsprite3 = ornamentobject3.AddComponent<SpriteRenderer>();
       ornamentsprite3.sprite = ModAPI.LoadSprite("image/Aramakihair2.png",2.8f);
       ornamentsprite3.sortingLayerName = "Top";

       var backpack = new GameObject("Aramakicape");
       backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
       backpack.transform.localPosition = new Vector3(0, 0f);
       backpack.transform.localScale = new Vector3(1f, 1f);
       var backpackSprite = backpack.AddComponent<SpriteRenderer>();
       backpackSprite.sprite = ModAPI.LoadSprite("image/Aramakicape.png");
       backpack.GetComponent<SpriteRenderer>().sortingLayerName = "middle";
       backpack.AddComponent<UseEventTrigger>().Action = () => {
       backpackSprite.sprite = ModAPI.LoadSprite("none.png");
       };

       var ca = new GameObject("Aramakisword");
       ca.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
       ca.transform.localPosition = new Vector3(0, 0f);
       ca.transform.localScale = new Vector3(1f, 1f);
       var caSprite = ca.AddComponent<SpriteRenderer>();
       caSprite.sprite = ModAPI.LoadSprite("image/Aramakisword.png");
       ca.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
       ca.AddComponent<UseEventTrigger>().Action = () => {
       caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                          };

      person.SetBruiseColor(000, 000, 000);
      person.SetSecondBruiseColor(000, 000, 000);
      person.SetThirdBruiseColor(000, 000, 000);
      person.SetBloodColour(000, 000, 000);
      person.SetRottenColour(000, 000, 000);

           }
           UseEventTrigger useEventTrigger0 = head.gameObject.AddComponent<UseEventTrigger>();
           useEventTrigger0.Event = new UnityEvent();
           useEventTrigger0.Event.AddListener(delegate ()
            {
              GameObject Projectile2 = GameObject.Instantiate(ModAPI.FindSpawnable("Aramakihand").Prefab);
              CatalogBehaviour.PerformMod(ModAPI.FindSpawnable("Aramakihand"), Projectile2);
              Projectile2.transform.SetParent(arm1.gameObject.transform);
              Projectile2.transform.position = arm1.transform.position + (-arm1.transform.up * 1f);
              Projectile2.transform.localPosition = new Vector3(0f, -0.55f);
              Projectile2.transform.localScale = arm1.transform.localScale;
              Projectile2.transform.eulerAngles = arm1.transform.eulerAngles;


              Projectile2.GetComponent<SpriteRenderer>().sortingLayerName = "Decals";

              Projectile2.gameObject.GetComponent<PhysicalBehaviour>().SpawnSpawnParticles = false;
              Projectile2.gameObject.AddComponent<FixedJoint2D>();
              Projectile2.gameObject.GetComponent<FixedJoint2D>().connectedBody = arm1.gameObject.GetComponent<Rigidbody2D>();
              var col = Projectile2.AddComponent<NoCollide>();
              col.NoCollideSetA = Projectile2.GetComponents<Collider2D>();
              col.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

              GameObject Projectile3 = GameObject.Instantiate(ModAPI.FindSpawnable("Aramakihand").Prefab);
              CatalogBehaviour.PerformMod(ModAPI.FindSpawnable("Aramakihand"), Projectile3);
              Projectile3.transform.SetParent(arm2.gameObject.transform);
              Projectile3.transform.position = arm2.transform.position + (-arm2.transform.up * 1f);
              Projectile3.transform.localPosition = new Vector3(0f, -0.55f);
              Projectile3.transform.localScale = arm2.transform.localScale;
              Projectile3.transform.eulerAngles = arm2.transform.eulerAngles;


              Projectile3.gameObject.GetComponent<PhysicalBehaviour>().SpawnSpawnParticles = false;
              Projectile3.gameObject.AddComponent<FixedJoint2D>();
              Projectile3.gameObject.GetComponent<FixedJoint2D>().connectedBody = arm2.gameObject.GetComponent<Rigidbody2D>();
              var col2 = Projectile3.AddComponent<NoCollide>();
              col2.NoCollideSetA = Projectile3.GetComponents<Collider2D>();
              col2.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

              UseEventTrigger useEventTrigger = upper.gameObject.AddComponent<UseEventTrigger>();
              useEventTrigger.Event = new UnityEvent();
              useEventTrigger.Event.AddListener(delegate ()
               {
                 Destroy(Projectile2);
                 Destroy(Projectile3);
              });

              UseEventTrigger useEventTrigger1 = Lower.gameObject.AddComponent<UseEventTrigger>();
              useEventTrigger1.Event = new UnityEvent();
              useEventTrigger1.Event.AddListener(delegate ()
               {
                Audio3.Play();
              });

           });


        }
     }
);

ModAPI.Register(
    new Modification()
        {
   OriginalItem = ModAPI.FindSpawnable("Human"),
   NameOverride = "Borsalino",
   NameToOrderByOverride = "Z1",
   DescriptionOverride = ""+"\n <color=white>Borsalino more commonly known by his alias Kizaru is an admiral in the Marines." + "\n <color=yellow>Kizaru",
   CategoryOverride = ModAPI.FindCategory("One Piece pack"),
   ThumbnailOverride = ModAPI.LoadSprite("image/Borsalinothumbnail.png"),
   AfterSpawn = (Instance) =>
   {

   var skin = ModAPI.LoadTexture("image/Borsalino.png");
   var flesh = ModAPI.LoadTexture("Flesh.png");
   var bone = ModAPI.LoadTexture("Bone.png");


   var person = Instance.GetComponent<PersonBehaviour>();

   var head = Instance.transform.Find("Head");
   var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
   var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
   var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
   var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
   var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
   var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
   var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
   var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
   var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
   var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
   var upper = Instance.transform.Find("Body").Find("UpperBody");
   var middle = Instance.transform.Find("Body").Find("MiddleBody");
   var Lower = Instance.transform.Find("Body").Find("LowerBody");

   upper.transform.localScale = new Vector3(1.4f, 1.2f);
   middle.transform.localScale = new Vector3(1.3f, 1.2f);
   Lower.transform.localScale = new Vector3(1.2f, 1f);
   arm3.transform.localScale = new Vector3(1.3f, 1.2f);
   arm4.transform.localScale = new Vector3(1.3f, 1.2f);
   arm1.transform.localScale = new Vector3(1.3f, 1.2f);
   arm2.transform.localScale = new Vector3(1.3f, 1.2f);
   leg3.transform.localScale = new Vector3(1.19f, 1.2f);
   leg4.transform.localScale = new Vector3(1.19f, 1.2f);
   leg1.transform.localScale = new Vector3(1.19f, 1.2f);
   leg2.transform.localScale = new Vector3(1.19f, 1.2f);
   foot1.transform.localScale = new Vector3(1.19f, 1.2f);
   foot2.transform.localScale = new Vector3(1.19f, 1.2f);
   head.transform.localScale = new Vector3(0.7f, 0.7f);

   head.transform.localPosition = new Vector3(0.02f, 0.700f);
   arm3.transform.localPosition = new Vector3(0f, -0.15f);
   arm4.transform.localPosition = new Vector3(0f, -0.15f);
   arm1.transform.localPosition = new Vector3(0f, -0.60f);
   arm2.transform.localPosition = new Vector3(0f, -0.60f);
   leg3.transform.localPosition = new Vector3(0f, -0.46f);
   leg4.transform.localPosition = new Vector3(0f, -0.46f);
   leg1.transform.localPosition = new Vector3(0f, -0.96f);
   leg2.transform.localPosition = new Vector3(0f, -0.96f);
   foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
   foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);

   AudioSource Audio3 = Instance.AddComponent<AudioSource>();
   Audio3.maxDistance = 10;
   Audio3.loop = false;
   Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");


   Lower.gameObject.AddComponent<kenbun>();
   arm1.gameObject.AddComponent<Busoshoku>();
   arm2.gameObject.AddComponent<Busoshoku>();

   AudioSource Audio = Instance.AddComponent<AudioSource>();
   Audio.maxDistance = 1;
   Audio.loop = true;
   Audio.clip = ModAPI.LoadSound("Sound/kizaruthem.mp3");


   AudioClip Repulsor = ModAPI.LoadSound("beam2.mp3");
   AudioClip beam2 = ModAPI.LoadSound("beam2.mp3");


   arm1.gameObject.AddComponent<GunBeh>();
   arm2.gameObject.AddComponent<GunBeh>();
   foot1.gameObject.AddComponent<GunBeh>();
   foot2.gameObject.AddComponent<GunBeh>();

   foreach (var Limbs in person.Limbs)
   {;

       if (Limbs.GetComponent<GripBehaviour>())
       {
           Limbs.gameObject.AddComponent<UseEventTrigger>().Action = () =>
           {


               AudioSource audio = Limbs.gameObject.AddComponent<AudioSource>();
               audio.spatialBlend = 1;
               audio.PlayOneShot(Repulsor);
           };
       }
   }



   person.SetBodyTextures(skin, flesh, bone, 1);
   foreach (var body in person.Limbs)
    {
       body.BaseStrength *= 0.5f;
       body.Health *= 10000000f;
       body.BreakingThreshold *= 100f;
       body.IsAndroid = true;
       body.transform.root.localScale *= 1.02f;
       body.PhysicalBehaviour.BurningProgressionMultiplier = -1000000;
       body.gameObject.AddComponent<strongrege>();
       UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger.Event = new UnityEvent();
       useEventTrigger.Event.AddListener(delegate ()
        {
          body.gameObject.layer = 10;
          body.ImmuneToDamage = true;
          body.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(255f, 255f, 0f, 1f);
          head.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(255f, 255f, 0f, 1f);
          Audio.Play();
       });

       UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger1.Event = new UnityEvent();
       useEventTrigger1.Event.AddListener(delegate ()
        {
          body.gameObject.layer = 9;
          body.ImmuneToDamage = false;
          body.SkinMaterialHandler.ClearAllDamage();
          body.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          upper.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
          Audio.Stop();
       });

       UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
       useEventTrigger2.Event = new UnityEvent();
       useEventTrigger2.Event.AddListener(delegate ()
        {
         Audio3.Play();
       });

    //cape13
     var backpack = new GameObject("cape13");
     backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
     backpack.transform.localPosition = new Vector3(0, 0f);
     backpack.transform.localScale = new Vector3(1f, 1f);
     var backpackSprite = backpack.AddComponent<SpriteRenderer>();
     backpackSprite.sprite = ModAPI.LoadSprite("image/cape13.png");
     backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
     backpack.AddComponent<UseEventTrigger>().Action = () => {
     backpackSprite.sprite = ModAPI.LoadSprite("none.png");

                                                              };

      person.SetBruiseColor(255, 255, 000);
      person.SetSecondBruiseColor(255, 255, 102);
      person.SetThirdBruiseColor(255, 255, 153);
      person.SetBloodColour(255, 255, 204);
      person.SetRottenColour(000, 000, 000);

           }
        }
     }
 );

 ModAPI.Register(
     new Modification()
         {
    OriginalItem = ModAPI.FindSpawnable("Human"),
    NameOverride = "Kuzan",
    NameToOrderByOverride = "Z1",
    DescriptionOverride = ""+"\n <color=white>Kuzan better known by his former epithet Aokiji is a Marine admiral and the first one to be revealed." + "\n <color=blue>Aokiji",
    CategoryOverride = ModAPI.FindCategory("One Piece pack"),
    ThumbnailOverride = ModAPI.LoadSprite("image/Kuzanthumnail.png"),
    AfterSpawn = (Instance) =>
    {

    var skin = ModAPI.LoadTexture("image/Kuzan.png");
    var flesh = ModAPI.LoadTexture("Flesh.png");
    var bone = ModAPI.LoadTexture("Bone.png");



    var person = Instance.GetComponent<PersonBehaviour>();

    var head = Instance.transform.Find("Head");
    var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
    var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
    var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
    var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
    var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
    var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
    var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
    var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
    var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
    var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
    var upper = Instance.transform.Find("Body").Find("UpperBody");
    var middle = Instance.transform.Find("Body").Find("MiddleBody");
    var Lower = Instance.transform.Find("Body").Find("LowerBody");

    upper.transform.localScale = new Vector3(1.4f, 1.2f);
    middle.transform.localScale = new Vector3(1.3f, 1.2f);
    Lower.transform.localScale = new Vector3(1.2f, 1f);
    arm3.transform.localScale = new Vector3(1.3f, 1.2f);
    arm4.transform.localScale = new Vector3(1.3f, 1.2f);
    arm1.transform.localScale = new Vector3(1.3f, 1.2f);
    arm2.transform.localScale = new Vector3(1.3f, 1.2f);
    leg3.transform.localScale = new Vector3(1.19f, 1.2f);
    leg4.transform.localScale = new Vector3(1.19f, 1.2f);
    leg1.transform.localScale = new Vector3(1.19f, 1.2f);
    leg2.transform.localScale = new Vector3(1.19f, 1.2f);
    foot1.transform.localScale = new Vector3(1.19f, 1.2f);
    foot2.transform.localScale = new Vector3(1.19f, 1.2f);
    head.transform.localScale = new Vector3(0.7f, 0.7f);

    head.transform.localPosition = new Vector3(0.02f, 0.700f);
    arm3.transform.localPosition = new Vector3(0f, -0.15f);
    arm4.transform.localPosition = new Vector3(0f, -0.15f);
    arm1.transform.localPosition = new Vector3(0f, -0.60f);
    arm2.transform.localPosition = new Vector3(0f, -0.60f);
    leg3.transform.localPosition = new Vector3(0f, -0.46f);
    leg4.transform.localPosition = new Vector3(0f, -0.46f);
    leg1.transform.localPosition = new Vector3(0f, -0.96f);
    leg2.transform.localPosition = new Vector3(0f, -0.96f);
    foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
    foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);

    AudioSource Audio3 = Instance.AddComponent<AudioSource>();
    Audio3.maxDistance = 10;
    Audio3.loop = false;
    Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");



    Lower.gameObject.AddComponent<kenbun>();
    arm1.gameObject.AddComponent<Busoshoku>();
    arm2.gameObject.AddComponent<Busoshoku>();

    AudioSource Audio = Instance.AddComponent<AudioSource>();
    Audio.maxDistance = 1;
    Audio.loop = false;
    Audio.clip = ModAPI.LoadSound("Sound/aokijithem.mp3");

    AudioClip Repulsor = ModAPI.LoadSound("iceage.mp3");
    AudioClip beam2 = ModAPI.LoadSound("iceage.mp3");


    arm1.gameObject.AddComponent<ice2>();
    arm2.gameObject.AddComponent<ice2>();

    foreach (var Limbs in person.Limbs)
    {;

        if (Limbs.GetComponent<GripBehaviour>())
        {
            Limbs.gameObject.AddComponent<UseEventTrigger>().Action = () =>
            {


                AudioSource audio = Limbs.gameObject.AddComponent<AudioSource>();
                audio.spatialBlend = 1;
                audio.PlayOneShot(Repulsor);
            };
        }
    }



    person.SetBodyTextures(skin, flesh, bone, 1);
    foreach (var body in person.Limbs)
     {
        body.BaseStrength *= 0.5f;
        body.Health *= 10000000f;
        body.BreakingThreshold *= 100f;
        body.IsAndroid = true;
        body.transform.root.localScale *= 1.02f;
        body.PhysicalBehaviour.BurningProgressionMultiplier = -1000000;
        body.gameObject.AddComponent<strongrege>();
        body.gameObject.AddComponent<Ice>();
        UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger.Event = new UnityEvent();
        useEventTrigger.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = true;
           body.gameObject.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Ice");
           body.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0f, 200f, 200f, 1f);
           head.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0f, 200f, 200f, 1f);
           Audio.Play();
        });

        UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger1.Event = new UnityEvent();
        useEventTrigger1.Event.AddListener(delegate ()
         {
           body.ImmuneToDamage = false;
           body.gameObject.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Human");
           body.SkinMaterialHandler.ClearAllDamage();
           body.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           upper.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
           Audio.Play();
        });

        UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
        useEventTrigger2.Event = new UnityEvent();
        useEventTrigger2.Event.AddListener(delegate ()
         {
          Audio3.Play();
        });

        var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
        var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


        ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

    //Kuzan item
      var ca = new GameObject("Kuzan item");
      ca.transform.SetParent(Instance.transform.Find("Head"));
      ca.transform.localPosition = new Vector3(0, 0f);
      ca.transform.localScale = new Vector3(1f, 1f);
      var caSprite = ca.AddComponent<SpriteRenderer>();
      caSprite.sprite = ModAPI.LoadSprite("image/Kuzan item.png");
      ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
      ca.AddComponent<UseEventTrigger>().Action = () => {
      caSprite.sprite = ModAPI.LoadSprite("none.png");
      };

      var ca2 = new GameObject("Kuzancape.png");
      ca2.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
      ca2.transform.localPosition = new Vector3(0, 0f);
      ca2.transform.localScale = new Vector3(1f, 1f);
      var caSprite2 = ca2.AddComponent<SpriteRenderer>();
      caSprite2.sprite = ModAPI.LoadSprite("image/Kuzancape.png");
      ca2.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
      ca2.AddComponent<UseEventTrigger>().Action = () => {
      caSprite2.sprite = ModAPI.LoadSprite("none.png");
      };

      var backpack = new GameObject("cape14");
      backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
      backpack.transform.localPosition = new Vector3(0, 0f);
      backpack.transform.localScale = new Vector3(1f, 1f);
      var backpackSprite = backpack.AddComponent<SpriteRenderer>();
      backpackSprite.sprite = ModAPI.LoadSprite("image/cape14.png");
      backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
      backpack.AddComponent<UseEventTrigger>().Action = () => {
      backpackSprite.sprite = ModAPI.LoadSprite("none.png");

                                                               };

       person.SetBruiseColor(255, 255, 255);
       person.SetSecondBruiseColor(000, 000, 153);
       person.SetThirdBruiseColor(255, 255, 255);
       person.SetBloodColour(000, 000, 102);
       person.SetRottenColour(000, 000, 000);

            }
         }
      }
  );

  ModAPI.Register(
          new Modification()
              {
         OriginalItem = ModAPI.FindSpawnable("Human"),
         NameOverride = "Sakazuki",
         NameToOrderByOverride = "Z1",
         DescriptionOverride = ""+"\n <color=white>Sakazuki formerly known by his admiral alias Akainu is the current fleet admiral of the Marines, succeeding the previous fleet admiral, Sengoku." + "\n <color=red>Akainu",
         CategoryOverride = ModAPI.FindCategory("One Piece pack"),
         ThumbnailOverride = ModAPI.LoadSprite("image/sakazukithumbnail.png"),
         AfterSpawn = (Instance) =>
         {

         var skin = ModAPI.LoadTexture("image/Sakazuki.png");
         var flesh = ModAPI.LoadTexture("Flesh.png");
         var bone = ModAPI.LoadTexture("Bone.png");


         var person = Instance.GetComponent<PersonBehaviour>();

         var head = Instance.transform.Find("Head");
         var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
         var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
         var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
         var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
         var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
         var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
         var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
         var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
         var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
         var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
         var upper = Instance.transform.Find("Body").Find("UpperBody");
         var middle = Instance.transform.Find("Body").Find("MiddleBody");
         var Lower = Instance.transform.Find("Body").Find("LowerBody");

         upper.transform.localScale = new Vector3(1.4f, 1.2f);
         middle.transform.localScale = new Vector3(1.3f, 1.2f);
         Lower.transform.localScale = new Vector3(1.2f, 1f);
         arm3.transform.localScale = new Vector3(1.3f, 1.2f);
         arm4.transform.localScale = new Vector3(1.3f, 1.2f);
         arm1.transform.localScale = new Vector3(1.3f, 1.2f);
         arm2.transform.localScale = new Vector3(1.3f, 1.2f);
         leg3.transform.localScale = new Vector3(1.19f, 1.2f);
         leg4.transform.localScale = new Vector3(1.19f, 1.2f);
         leg1.transform.localScale = new Vector3(1.19f, 1.2f);
         leg2.transform.localScale = new Vector3(1.19f, 1.2f);
         foot1.transform.localScale = new Vector3(1.19f, 1.2f);
         foot2.transform.localScale = new Vector3(1.19f, 1.2f);
         head.transform.localScale = new Vector3(0.7f, 0.7f);

         head.transform.localPosition = new Vector3(0.02f, 0.700f);
         arm3.transform.localPosition = new Vector3(0f, -0.15f);
         arm4.transform.localPosition = new Vector3(0f, -0.15f);
         arm1.transform.localPosition = new Vector3(0f, -0.60f);
         arm2.transform.localPosition = new Vector3(0f, -0.60f);
         leg3.transform.localPosition = new Vector3(0f, -0.46f);
         leg4.transform.localPosition = new Vector3(0f, -0.46f);
         leg1.transform.localPosition = new Vector3(0f, -0.96f);
         leg2.transform.localPosition = new Vector3(0f, -0.96f);
         foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
         foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);

         AudioSource Audio3 = Instance.AddComponent<AudioSource>();
         Audio3.maxDistance = 10;
         Audio3.loop = false;
         Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

         Lower.gameObject.AddComponent<kenbun>();
         arm1.gameObject.AddComponent<Busoshoku>();
         arm2.gameObject.AddComponent<Busoshoku>();

         AudioSource Audio = Instance.AddComponent<AudioSource>();
         Audio.maxDistance = 1;
         Audio.loop = true;
         Audio.clip = ModAPI.LoadSound("Sound/akainuthem.mp3");

         AudioClip Repulsor = ModAPI.LoadSound("ryusekazan.mp3");
         AudioClip beam2 = ModAPI.LoadSound("ryusekazan.mp3");


         arm1.gameObject.AddComponent<Crush>();
         arm2.gameObject.AddComponent<Crush>();
         arm1.gameObject.AddComponent<Firebeh>();
         arm2.gameObject.AddComponent<Firebeh>();
         arm1.gameObject.AddComponent<mg1>();
         arm2.gameObject.AddComponent<mg1>();

         foreach (var Limbs in person.Limbs)
         {;

             if (Limbs.GetComponent<GripBehaviour>())
             {
                 Limbs.gameObject.AddComponent<UseEventTrigger>().Action = () =>
                 {


                     AudioSource audio = Limbs.gameObject.AddComponent<AudioSource>();
                     audio.spatialBlend = 1;
                     audio.PlayOneShot(Repulsor);
                 };
             }
         }


         person.SetBodyTextures(skin, flesh, bone, 1);
         foreach (var body in person.Limbs)
          {
             body.BaseStrength *= 0.5f;
             body.Health *= 10000000f;
             body.BreakingThreshold *= 100f;
             body.IsAndroid = true;
             body.transform.root.localScale *= 1.02f;
             body.PhysicalBehaviour.BurningProgressionMultiplier = -1000000;
             body.gameObject.AddComponent<strongrege>();
             UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
             useEventTrigger.Event = new UnityEvent();
             useEventTrigger.Event.AddListener(delegate ()
              {
                body.ImmuneToDamage = true;

                body.gameObject.GetComponent<PhysicalBehaviour>().Temperature = 200f;
                body.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 0.3f, 0f, 1f);
                head.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 0.3f, 0f, 1f);
                Audio.Play();
             });

             UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
             useEventTrigger1.Event = new UnityEvent();
             useEventTrigger1.Event.AddListener(delegate ()
              {
                body.gameObject.GetComponent<PhysicalBehaviour>().Temperature = 37f;
                body.ImmuneToDamage = false;
                body.SkinMaterialHandler.ClearAllDamage();
                body.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                upper.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
                Audio.Stop();
             });

             UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
             useEventTrigger2.Event = new UnityEvent();
             useEventTrigger2.Event.AddListener(delegate ()
              {
               Audio3.Play();
             });


             var ca = new GameObject("Hat2");
             ca.transform.SetParent(Instance.transform.Find("Head"));
             ca.transform.localPosition = new Vector3(0, 0f);
             ca.transform.localScale = new Vector3(1f, 1f);
             var caSprite = ca.AddComponent<SpriteRenderer>();
             caSprite.sprite = ModAPI.LoadSprite("image/Hat2.png");
             ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
             ca.AddComponent<UseEventTrigger>().Action = () => {
             caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                               };


              var ca2 = new GameObject("akainuflower");
              ca2.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
              ca2.transform.localPosition = new Vector3(0, 0f);
              ca2.transform.localScale = new Vector3(1f, 1f);
              var ca2Sprite = ca2.AddComponent<SpriteRenderer>();
              ca2Sprite.sprite = ModAPI.LoadSprite("image/akainuflower.png");
              ca2.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
              ca2.AddComponent<UseEventTrigger>().Action = () => {
              ca2Sprite.sprite = ModAPI.LoadSprite("none.png");
                                                                 };

          //cape11
           var backpack = new GameObject("cape11");
           backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
           backpack.transform.localPosition = new Vector3(0, 0f);
           backpack.transform.localScale = new Vector3(1f, 1f);
           var backpackSprite = backpack.AddComponent<SpriteRenderer>();
           backpackSprite.sprite = ModAPI.LoadSprite("image/cape11.png");
           backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
           backpack.AddComponent<UseEventTrigger>().Action = () => {
           backpackSprite.sprite = ModAPI.LoadSprite("none.png");

            };


            person.SetBruiseColor(153, 000, 000);
            person.SetSecondBruiseColor(204, 000, 000);
            person.SetThirdBruiseColor(204, 000, 000);
            person.SetBloodColour(255, 000, 000);
            person.SetRottenColour(102, 000, 000);

                 }
              }
           }
  );

  ModAPI.Register(
      new Modification()
          {
     OriginalItem = ModAPI.FindSpawnable("Human"),
     NameOverride = ""+"\n <color=blue>Enel",
     NameToOrderByOverride = "Z1",
     DescriptionOverride = ""+"\n <color=white>Enel is the former tyrannical God of Skypiea.",
     CategoryOverride = ModAPI.FindCategory("One Piece pack"),
     ThumbnailOverride = ModAPI.LoadSprite("image/enelthumbnail.png"),
     AfterSpawn = (Instance) =>
     {

     var skin = ModAPI.LoadTexture("image/Enel.png");
     var flesh = ModAPI.LoadTexture("Flesh.png");
     var bone = ModAPI.LoadTexture("Bone.png");


     var person = Instance.GetComponent<PersonBehaviour>();
     var head = Instance.transform.Find("Head");
     var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
     var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
     var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
     var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
     var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
     var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
     var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
     var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
     var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
     var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
     var upper = Instance.transform.Find("Body").Find("UpperBody");
     var middle = Instance.transform.Find("Body").Find("MiddleBody");
     var Lower = Instance.transform.Find("Body").Find("LowerBody");

     upper.transform.localScale = new Vector3(1.3f, 1.2f);
     middle.transform.localScale = new Vector3(1.1f, 1.2f);
     head.transform.localScale = new Vector3(0.7f, 0.7f);
     arm3.transform.localScale = new Vector3(1.18f, 1.2f);
     arm4.transform.localScale = new Vector3(1.18f, 1.2f);
     arm1.transform.localScale = new Vector3(1.18f, 1.2f);
     arm2.transform.localScale = new Vector3(1.18f, 1.2f);
     leg3.transform.localScale = new Vector3(1.19f, 1.2f);
     leg4.transform.localScale = new Vector3(1.19f, 1.2f);
     leg1.transform.localScale = new Vector3(1.19f, 1.2f);
     leg2.transform.localScale = new Vector3(1.19f, 1.2f);
     foot1.transform.localScale = new Vector3(1.19f, 1.2f);
     foot2.transform.localScale = new Vector3(1.19f, 1.2f);

     head.transform.localPosition = new Vector3(0.01f, 0.700f);
     arm3.transform.localPosition = new Vector3(0f, -0.15f);
     arm4.transform.localPosition = new Vector3(0f, -0.15f);
     arm1.transform.localPosition = new Vector3(0f, -0.60f);
     arm2.transform.localPosition = new Vector3(0f, -0.60f);
     leg3.transform.localPosition = new Vector3(0f, -0.46f);
     leg4.transform.localPosition = new Vector3(0f, -0.46f);
     leg1.transform.localPosition = new Vector3(0f, -0.96f);
     leg2.transform.localPosition = new Vector3(0f, -0.96f);
     foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
     foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);
     AudioSource Audio = Instance.AddComponent<AudioSource>();
     Audio.maxDistance = 1;
     Audio.loop = true;
     Audio.clip = ModAPI.LoadSound("Sound/enelethem.mp3");

     AudioSource Audio3 = Instance.AddComponent<AudioSource>();
     Audio3.maxDistance = 10;
     Audio3.loop = false;
     Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

     AudioClip Repulsor = ModAPI.LoadSound("enelthor.mp3");
     AudioClip beam2 = ModAPI.LoadSound("enelthor.mp3");


     Lower.gameObject.AddComponent<kenbun>();
     arm1.gameObject.AddComponent<Lightning>();
     arm2.gameObject.AddComponent<Lightning>();
     arm1.gameObject.AddComponent<spark>();
     arm2.gameObject.AddComponent<spark>();

     foreach (var Limbs in person.Limbs)
     {;

         if (Limbs.GetComponent<GripBehaviour>())
         {
             Limbs.gameObject.AddComponent<UseEventTrigger>().Action = () =>
             {


                 AudioSource audio = Limbs.gameObject.AddComponent<AudioSource>();
                 audio.spatialBlend = 1;
                 audio.PlayOneShot(Repulsor);
             };
         }
     }


     person.SetBodyTextures(skin, flesh, bone, 1);
     foreach (var body in person.Limbs)
      {
         body.BaseStrength *= 0.4f;
         body.Health *= 1000f;
         body.BreakingThreshold *= 1f;
         body.IsAndroid = true;
         body.transform.root.localScale *= 1.01f;
         body.gameObject.AddComponent<regenstuffnthing>();

         UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
         useEventTrigger.Event = new UnityEvent();
         useEventTrigger.Event.AddListener(delegate ()
          {
            body.ImmuneToDamage = true;
            body.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0f, 210f, 210f, 1f);
            head.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(0f, 210f, 210f, 1f);
            Audio.Play();
         });

         UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
         useEventTrigger1.Event = new UnityEvent();
         useEventTrigger1.Event.AddListener(delegate ()
          {
            body.ImmuneToDamage = false;
            body.SkinMaterialHandler.ClearAllDamage();
            body.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            upper.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            Audio.Stop();
         });

         UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
         useEventTrigger2.Event = new UnityEvent();
         useEventTrigger2.Event.AddListener(delegate ()
          {
            Audio3.Play();
         });

      //cape18
       var backpack = new GameObject("cape18");
       backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
       backpack.transform.localPosition = new Vector3(0, 0f);
       backpack.transform.localScale = new Vector3(1f, 1f);
       var backpackSprite = backpack.AddComponent<SpriteRenderer>();
       backpackSprite.sprite = ModAPI.LoadSprite("image/cape18.png");
       backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
       backpack.AddComponent<UseEventTrigger>().Action = () => {
       backpackSprite.sprite = ModAPI.LoadSprite("none.png");

                                                                };

       person.SetBruiseColor(000, 255, 255);
       person.SetSecondBruiseColor(000, 051, 204);
       person.SetThirdBruiseColor(51, 051, 255);
       person.SetBloodColour(255, 255, 255);
       person.SetRottenColour(000, 000, 000);


             }
          }
       }
   );

   ModAPI.Register(
       new Modification()
           {
      OriginalItem = ModAPI.FindSpawnable("Human"),
      NameOverride = "Marco",
      NameToOrderByOverride = "Z1",
      DescriptionOverride = "Marco the Phoenix is the former 1st division commander of the Whitebeard Pirates. Once starting out as an apprentice on the crew he had come to be Whitebeard's closest confidant and right-hand ma.",
      CategoryOverride = ModAPI.FindCategory("One Piece pack"),
      ThumbnailOverride = ModAPI.LoadSprite("image/Marcothumbnail.png"),
      AfterSpawn = (Instance) =>
      {

      var skin = ModAPI.LoadTexture("image/Marco.png");
      var flesh = ModAPI.LoadTexture("Flesh.png");
      var bone = ModAPI.LoadTexture("Bone.png");


      var person = Instance.GetComponent<PersonBehaviour>();
      var head = Instance.transform.Find("Head");
      var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
      var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
      var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
      var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
      var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
      var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
      var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
      var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
      var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
      var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
      var upper = Instance.transform.Find("Body").Find("UpperBody");
      var middle = Instance.transform.Find("Body").Find("MiddleBody");
      var Lower = Instance.transform.Find("Body").Find("LowerBody");

      upper.transform.localScale = new Vector3(1.3f, 1.2f);
      middle.transform.localScale = new Vector3(1.1f, 1.2f);
      head.transform.localScale = new Vector3(0.7f, 0.7f);
      arm3.transform.localScale = new Vector3(1.18f, 1.2f);
      arm4.transform.localScale = new Vector3(1.18f, 1.2f);
      arm1.transform.localScale = new Vector3(1.18f, 1.2f);
      arm2.transform.localScale = new Vector3(1.18f, 1.2f);
      leg3.transform.localScale = new Vector3(1.43f, 1.2f);
      leg4.transform.localScale = new Vector3(1.43f, 1.2f);
      leg1.transform.localScale = new Vector3(1.19f, 1.2f);
      leg2.transform.localScale = new Vector3(1.19f, 1.2f);
      foot1.transform.localScale = new Vector3(1.19f, 1.2f);
      foot2.transform.localScale = new Vector3(1.19f, 1.2f);


      head.transform.localPosition = new Vector3(0.01f, 0.700f);
      arm3.transform.localPosition = new Vector3(0f, -0.15f);
      arm4.transform.localPosition = new Vector3(0f, -0.15f);
      arm1.transform.localPosition = new Vector3(0f, -0.60f);
      arm2.transform.localPosition = new Vector3(0f, -0.60f);
      leg3.transform.localPosition = new Vector3(0f, -0.46f);
      leg4.transform.localPosition = new Vector3(0f, -0.46f);
      leg1.transform.localPosition = new Vector3(0f, -0.96f);
      leg2.transform.localPosition = new Vector3(0f, -0.96f);
      foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
      foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);

      AudioSource Audio3 = Instance.AddComponent<AudioSource>();
      Audio3.maxDistance = 10;
      Audio3.loop = false;
      Audio3.clip = ModAPI.LoadSound("Sound/kenbunhaki.mp3");

      Lower.gameObject.AddComponent<kenbun>();
      foot1.gameObject.AddComponent<Busoshoku>();
      foot2.gameObject.AddComponent<Busoshoku>();


      person.SetBodyTextures(skin, flesh, bone, 1);
      foreach (var body in person.Limbs)
       {
          body.BaseStrength *= 0.5f;
          body.Health *= 100f;
          body.BreakingThreshold *= 1f;
          body.IsAndroid = true;
          body.transform.root.localScale *= 1.01f;
          body.gameObject.AddComponent<regenstuffnthing>();
          UseEventTrigger useEventTrigger2 = Lower.gameObject.AddComponent<UseEventTrigger>();
          useEventTrigger2.Event = new UnityEvent();
          useEventTrigger2.Event.AddListener(delegate ()
           {
             Audio3.Play();
          });

        var ornamentobject = new GameObject("marcohair.png");
        ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
        ornamentobject.transform.localPosition = new Vector3(0f, 0.03f);
        ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        ornamentobject.transform.localScale = new Vector3(1f, 1f);
        var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
        ornamentsprite.sprite = ModAPI.LoadSprite("image/marcohair.png",1f);
        ornamentsprite.sortingLayerName = "Top";

        var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
        var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");


        ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
        ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

        person.SetBruiseColor(000, 255, 255);
        person.SetSecondBruiseColor(051, 255, 255);
        person.SetThirdBruiseColor(255, 255, 000);
        person.SetBloodColour(255, 255, 255);
        person.SetRottenColour(000, 000, 000);


              }
           }
        }
  );

  ModAPI.Register(
      new Modification()
          {
     OriginalItem = ModAPI.FindSpawnable("Human"),
     NameOverride = "Marco hybrid form",
     NameToOrderByOverride = "Z1",
     DescriptionOverride = "Marco phoenix form.",
     CategoryOverride = ModAPI.FindCategory("One Piece pack"),
     ThumbnailOverride = ModAPI.LoadSprite("image/Marco hybrid formthumb.png"),
     AfterSpawn = (Instance) =>
     {

     var skin = ModAPI.LoadTexture("image/Marco hybrid form.png");
     var flesh = ModAPI.LoadTexture("Flesh.png");
     var bone = ModAPI.LoadTexture("Bone.png");


     var person = Instance.GetComponent<PersonBehaviour>();
     var head = Instance.transform.Find("Head");
     var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
     var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
     var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
     var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
     var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
     var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
     var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
     var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
     var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
     var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
     var upper = Instance.transform.Find("Body").Find("UpperBody");
     var middle = Instance.transform.Find("Body").Find("MiddleBody");
     var Lower = Instance.transform.Find("Body").Find("LowerBody");

     upper.transform.localScale = new Vector3(1.3f, 1.2f);
     middle.transform.localScale = new Vector3(1.1f, 1.2f);
     head.transform.localScale = new Vector3(0.7f, 0.7f);
     arm3.transform.localScale = new Vector3(1.18f, 1.2f);
     arm4.transform.localScale = new Vector3(1.18f, 1.2f);
     arm1.transform.localScale = new Vector3(1.18f, 1.2f);
     arm2.transform.localScale = new Vector3(1.18f, 1.2f);
     leg3.transform.localScale = new Vector3(1.43f, 1.2f);
     leg4.transform.localScale = new Vector3(1.43f, 1.2f);
     leg1.transform.localScale = new Vector3(1.19f, 1.2f);
     leg2.transform.localScale = new Vector3(1.19f, 1.2f);
     foot1.transform.localScale = new Vector3(1.12f, 1.2f);
     foot2.transform.localScale = new Vector3(1.12f, 1.2f);


     head.transform.localPosition = new Vector3(0.01f, 0.700f);
     arm3.transform.localPosition = new Vector3(0f, -0.15f);
     arm4.transform.localPosition = new Vector3(0f, -0.15f);
     arm1.transform.localPosition = new Vector3(0f, -0.60f);
     arm2.transform.localPosition = new Vector3(0f, -0.60f);
     leg3.transform.localPosition = new Vector3(0f, -0.46f);
     leg4.transform.localPosition = new Vector3(0f, -0.46f);
     leg1.transform.localPosition = new Vector3(0f, -0.96f);
     leg2.transform.localPosition = new Vector3(0f, -0.96f);
     foot1.transform.localPosition = new Vector3(0.059f, -1.2513f);
     foot2.transform.localPosition = new Vector3(0.059f, -1.2513f);

     leg1.gameObject.AddComponent<Busoshoku>();
     leg2.gameObject.AddComponent<Busoshoku>();

     GameObject horn = GameObject.Instantiate(ModAPI.FindSpawnable("Knife").Prefab);
     horn.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/Marco hybrid formBeak.png",1,true);
     horn.transform.SetParent(person.Limbs[0].transform);
     horn.transform.position = person.Limbs[0].transform.TransformPoint(new Vector2(0.1f, -0.1f));
     horn.transform.rotation = person.Limbs[0].transform.rotation;
     horn.transform.localPosition = new Vector3(0.2f, -0.07f, 0);
     horn.transform.localEulerAngles += new Vector3(0, 0, -90);
     horn.transform.localScale = Vector2.one;
     horn.GetComponent<PhysicalBehaviour>().MakeWeightless();
     horn.FixColliders();
     horn.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
     horn.AddComponent<FixedJoint2D>().connectedBody = person.Limbs[0].PhysicalBehaviour.rigidbody;
     horn.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
     var col = horn.AddComponent<NoCollide>();
     col.NoCollideSetA = horn.GetComponents<Collider2D>();
     col.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

     GameObject horn2 = GameObject.Instantiate(ModAPI.FindSpawnable("Brick").Prefab);
     horn2.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/Marco hybrid formwing.png",1,true);
     horn2.transform.SetParent(person.Limbs[1].transform);
     horn2.transform.position = person.Limbs[1].transform.TransformPoint(new Vector2(0.1f, -0.1f));
     horn2.transform.rotation = person.Limbs[1].transform.rotation;
     horn2.transform.localPosition = new Vector3(-0.9f, 0.09f, 0);
     horn2.transform.localEulerAngles += new Vector3(0, 0, 0);
     horn2.transform.localScale = Vector2.one;
     horn2.GetComponent<PhysicalBehaviour>().MakeWeightless();
     horn2.FixColliders();
     horn2.GetComponent<SpriteRenderer>().sortingLayerName = "Bottom";
     horn2.AddComponent<FixedJoint2D>().connectedBody = person.Limbs[1].PhysicalBehaviour.rigidbody;
     horn2.GetComponent<PhysicalBehaviour>().HoldingPositions = null;
     var col2 = horn2.AddComponent<NoCollide>();
     col2.NoCollideSetA = horn2.GetComponents<Collider2D>();
     col2.NoCollideSetB = Instance.GetComponentsInChildren<Collider2D>();

     person.SetBodyTextures(skin, flesh, bone, 1);
     foreach (var body in person.Limbs)
      {
         body.BaseStrength *= 1f;
         body.Health *= 100f;
         body.BreakingThreshold *= 1f;
         body.IsAndroid = true;
         body.transform.root.localScale *= 1.04f;
         body.gameObject.AddComponent<regenstuffnthing>();

         Instance.transform.Find("FrontLeg").Find("FootFront").GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/Marcofoot.png");
         Instance.transform.Find("FrontLeg").Find("FootFront").GetComponent<SpriteRenderer>().material.SetTexture("_FleshTex", ModAPI.LoadTexture("image/Marcobonefoot.png"));
         Instance.transform.Find("FrontLeg").Find("FootFront").GetComponent<SpriteRenderer>().material.SetTexture("_BoneTex", ModAPI.LoadTexture("image/Marcomeatfoot.png"));

         Instance.transform.Find("BackLeg").Find("Foot").GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/Marcofoot.png");
         Instance.transform.Find("BackLeg").Find("Foot").GetComponent<SpriteRenderer>().material.SetTexture("_FleshTex", ModAPI.LoadTexture("image/Marcobonefoot.png"));
         Instance.transform.Find("BackLeg").Find("Foot").GetComponent<SpriteRenderer>().material.SetTexture("_BoneTex", ModAPI.LoadTexture("image/Marcomeatfoot.png"));

         var hitbox1 = foot1.gameObject.AddComponent<BoxCollider2D>();
         var hitbox2 = foot2.gameObject.AddComponent<BoxCollider2D>();

         var allColliders = Instance.GetComponentsInChildren<Collider2D>();
         foreach (var a in allColliders)
             foreach (var b in allColliders)
                 Physics2D.IgnoreCollision(a, b);

         var ornamentobject = new GameObject("Marco hybrid formhat.png");
         ornamentobject.transform.SetParent(Instance.transform.Find("Head"));
         ornamentobject.transform.localPosition = new Vector3(-0.03f, 0.03f);
         ornamentobject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
         ornamentobject.transform.localScale = new Vector3(1f, 1f);
         var ornamentsprite = ornamentobject.AddComponent<SpriteRenderer>();
         ornamentsprite.sprite = ModAPI.LoadSprite("image/Marco hybrid formhat.png",1.5f);
         ornamentsprite.sortingLayerName = "Middle";

         var ornamentobject2 = new GameObject("Marco hybrid formtail");
         ornamentobject2.transform.SetParent(Instance.transform.Find("Body").Find("LowerBody"));
         ornamentobject2.transform.localPosition = new Vector3(-0.03f, 0.03f);
         ornamentobject2.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
         ornamentobject2.transform.localScale = new Vector3(1f, 1f);
         var ornamentsprite2 = ornamentobject2.AddComponent<SpriteRenderer>();
         ornamentsprite2.sprite = ModAPI.LoadSprite("image/Marco hybrid formtail.png",1f);
         ornamentsprite2.sortingLayerName = "Middle";

       var ArmDown = Instance.transform.Find("FrontArm").Find("LowerArmFront");
       var ArmTop = Instance.transform.Find("FrontArm").Find("UpperArmFront");

       ArmDown.GetComponent<SpriteRenderer>().sortingLayerName = "Top";
       ArmTop.GetComponent<SpriteRenderer>().sortingLayerName = "Top";

       person.SetBruiseColor(000, 255, 255);
       person.SetSecondBruiseColor(051, 255, 255);
       person.SetThirdBruiseColor(255, 255, 000);
       person.SetBloodColour(255, 255, 255);
       person.SetRottenColour(000, 000, 000);

             }
          }
       }
  );

  ModAPI.Register(
      new Modification()
          {
     OriginalItem = ModAPI.FindSpawnable("Human"),
     NameOverride = "Arlong",
     NameToOrderByOverride = "Z1",
     DescriptionOverride = "Arlong the Saw is a sawshark fish-man. He was the captain of the all fish-man crew (excluding Nami), the Arlong Pirates, a former member of the Sun Pirates.",
     CategoryOverride = ModAPI.FindCategory("One Piece pack"),
     ThumbnailOverride = ModAPI.LoadSprite("image/Arlongthumbnail.png"),
     AfterSpawn = (Instance) =>
     {

     var skin = ModAPI.LoadTexture("image/Arlong.png");
     var flesh = ModAPI.LoadTexture("Flesh.png");
     var bone = ModAPI.LoadTexture("Bone.png");
     var head = Instance.transform.Find("Head");
     var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
     var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
     var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
     var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
     var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
     var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
     var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
     var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
     var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
     var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
     var upper = Instance.transform.Find("Body").Find("UpperBody");
     var middle = Instance.transform.Find("Body").Find("MiddleBody");
     var Lower = Instance.transform.Find("Body").Find("LowerBody");

     upper.transform.localScale = new Vector3(1.3f, 1.2f);
     middle.transform.localScale = new Vector3(1.1f, 1.2f);
     head.transform.localScale = new Vector3(0.7f, 0.7f);
     arm3.transform.localScale = new Vector3(1.18f, 1.2f);
     arm4.transform.localScale = new Vector3(1.18f, 1.2f);
     arm1.transform.localScale = new Vector3(1.18f, 1.2f);
     arm2.transform.localScale = new Vector3(1.18f, 1.2f);
     leg3.transform.localScale = new Vector3(1.43f, 1.2f);
     leg4.transform.localScale = new Vector3(1.43f, 1.2f);
     leg1.transform.localScale = new Vector3(1.19f, 1.2f);
     leg2.transform.localScale = new Vector3(1.19f, 1.2f);
     foot1.transform.localScale = new Vector3(1.19f, 1.2f);
     foot2.transform.localScale = new Vector3(1.19f, 1.2f);

     head.transform.localPosition = new Vector3(0.01f, 0.700f);
     arm3.transform.localPosition = new Vector3(0f, -0.15f);
     arm4.transform.localPosition = new Vector3(0f, -0.15f);
     arm1.transform.localPosition = new Vector3(0f, -0.60f);
     arm2.transform.localPosition = new Vector3(0f, -0.60f);
     leg3.transform.localPosition = new Vector3(0f, -0.46f);
     leg4.transform.localPosition = new Vector3(0f, -0.46f);
     leg1.transform.localPosition = new Vector3(0f, -0.96f);
     leg2.transform.localPosition = new Vector3(0f, -0.96f);
     foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
     foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);

     var headyss = Instance.transform.Find("Head");
             var phys12 = headyss.GetComponent<PhysicalBehaviour>();
             var prop12 = ModAPI.FindPhysicalProperties("Human");
             prop12.Sharp = true;
             prop12.SharpAxes = new[]
             {
                 new SharpAxis(Vector2.right, 0f, 0.15f, true, true),
             };
             phys12.Properties = prop12;


     var person = Instance.GetComponent<PersonBehaviour>();
     person.SetBodyTextures(skin, flesh, bone, 1);
     foreach (var body in person.Limbs)
      {
          body.BaseStrength *= 1f;
          body.Health *= 500f;
          body.BreakingThreshold *= 10f;
          body.transform.root.localScale *= 1.01f;

          var ca = new GameObject("Arlonghat.png");
          ca.transform.SetParent(Instance.transform.Find("Head"));
          ca.transform.localPosition = new Vector3(0, 0f);
          ca.transform.localScale = new Vector3(1f, 1f);
          var caSprite = ca.AddComponent<SpriteRenderer>();
          caSprite.sprite = ModAPI.LoadSprite("image/Arlonghat.png");
          ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
          ca.AddComponent<UseEventTrigger>().Action = () => {
          caSprite.sprite = ModAPI.LoadSprite("none.png");
                                                            };

          var ca2 = new GameObject("Arlongfin.png");
          ca2.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
          ca2.transform.localPosition = new Vector3(0, 0f);
          ca2.transform.localScale = new Vector3(1f, 1f);
          var ca2Sprite = ca2.AddComponent<SpriteRenderer>();
          ca2Sprite.sprite = ModAPI.LoadSprite("image/Arlongfin.png");
          ca2.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
          ca2.AddComponent<UseEventTrigger>().Action = () => {
          ca2Sprite.sprite = ModAPI.LoadSprite("none.png");
                                                            };



                          }
                      }
                  }
  );


  ModAPI.Register(
      new Modification()
          {
     OriginalItem = ModAPI.FindSpawnable("Human"),
     NameOverride = "Smoker",
     NameToOrderByOverride = "Z1",
     DescriptionOverride = "Smoker the White Hunter is a Marine officer and the Commander of the G-5 Marine Base,  At some point during the timeskip he was promoted to the rank of vice admiral.",
     CategoryOverride = ModAPI.FindCategory("One Piece pack"),
     ThumbnailOverride = ModAPI.LoadSprite("image/Smokerthumbnail.png"),
     AfterSpawn = (Instance) =>
     {

     var skin = ModAPI.LoadTexture("image/Smoker.png");
     var flesh = ModAPI.LoadTexture("Flesh.png");
     var bone = ModAPI.LoadTexture("Bone.png");

     var head = Instance.transform.Find("Head");
     var arm3 = Instance.transform.Find("FrontArm").Find("UpperArmFront");
     var arm4 = Instance.transform.Find("BackArm").Find("UpperArm");
     var arm1 = Instance.transform.Find("FrontArm").Find("LowerArmFront");
     var arm2 = Instance.transform.Find("BackArm").Find("LowerArm");
     var foot1 = Instance.transform.Find("FrontLeg").Find("FootFront");
     var foot2 = Instance.transform.Find("BackLeg").Find("Foot");
     var leg1 = Instance.transform.Find("FrontLeg").Find("LowerLegFront");
     var leg2 = Instance.transform.Find("BackLeg").Find("LowerLeg");
     var leg3 = Instance.transform.Find("FrontLeg").Find("UpperLegFront");
     var leg4 = Instance.transform.Find("BackLeg").Find("UpperLeg");
     var upper = Instance.transform.Find("Body").Find("UpperBody");
     var middle = Instance.transform.Find("Body").Find("MiddleBody");
     var Lower = Instance.transform.Find("Body").Find("LowerBody");

     upper.transform.localScale = new Vector3(1.3f, 1.2f);
     middle.transform.localScale = new Vector3(1.1f, 1.2f);
     head.transform.localScale = new Vector3(0.7f, 0.7f);
     arm3.transform.localScale = new Vector3(1.18f, 1.2f);
     arm4.transform.localScale = new Vector3(1.18f, 1.2f);
     arm1.transform.localScale = new Vector3(1.18f, 1.2f);
     arm2.transform.localScale = new Vector3(1.18f, 1.2f);
     leg3.transform.localScale = new Vector3(1.19f, 1.2f);
     leg4.transform.localScale = new Vector3(1.19f, 1.2f);
     leg1.transform.localScale = new Vector3(1.19f, 1.2f);
     leg2.transform.localScale = new Vector3(1.19f, 1.2f);
     foot1.transform.localScale = new Vector3(1.19f, 1.2f);
     foot2.transform.localScale = new Vector3(1.19f, 1.2f);

     head.transform.localPosition = new Vector3(0.01f, 0.700f);
     arm3.transform.localPosition = new Vector3(0f, -0.15f);
     arm4.transform.localPosition = new Vector3(0f, -0.15f);
     arm1.transform.localPosition = new Vector3(0f, -0.60f);
     arm2.transform.localPosition = new Vector3(0f, -0.60f);
     leg3.transform.localPosition = new Vector3(0f, -0.46f);
     leg4.transform.localPosition = new Vector3(0f, -0.46f);
     leg1.transform.localPosition = new Vector3(0f, -0.96f);
     leg2.transform.localPosition = new Vector3(0f, -0.96f);
     foot1.transform.localPosition = new Vector3(0.068f, -1.2513f);
     foot2.transform.localPosition = new Vector3(0.068f, -1.2513f);

     var person = Instance.GetComponent<PersonBehaviour>();
     person.SetBodyTextures(skin, flesh, bone, 1);
     foreach (var body in person.Limbs)
      {
         body.BaseStrength *= 0.3f;
         body.Health *= 700f;
         body.BreakingThreshold *= 1f;
         body.IsAndroid = true;
         body.transform.root.localScale *= 1f;
         body.gameObject.AddComponent<strongrege>();

         UseEventTrigger useEventTrigger = head.gameObject.AddComponent<UseEventTrigger>();
         useEventTrigger.Event = new UnityEvent();
         useEventTrigger.Event.AddListener(delegate ()
          {
            body.ImmuneToDamage = true;
            body.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 1f);
            head.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 1f);

         });

         UseEventTrigger useEventTrigger1 = upper.gameObject.AddComponent<UseEventTrigger>();
         useEventTrigger1.Event = new UnityEvent();
         useEventTrigger1.Event.AddListener(delegate ()
          {
            body.ImmuneToDamage = false;
            body.SkinMaterialHandler.ClearAllDamage();
            body.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            upper.gameObject.GetOrAddComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);

         });


      //cape15
       var backpack = new GameObject("cape15");
       backpack.transform.SetParent(Instance.transform.Find("Body").Find("UpperBody"));
       backpack.transform.localPosition = new Vector3(0, 0f);
       backpack.transform.localScale = new Vector3(1f, 1f);
       var backpackSprite = backpack.AddComponent<SpriteRenderer>();
       backpackSprite.sprite = ModAPI.LoadSprite("image/cape15.png");
       backpack.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
       backpack.AddComponent<UseEventTrigger>().Action = () => {
       backpackSprite.sprite = ModAPI.LoadSprite("none.png");

                                                               };

     //Smokertobacco
       var ca = new GameObject("Smokertobacco");
       ca.transform.SetParent(Instance.transform.Find("Head"));
       ca.transform.localPosition = new Vector3(0, 0f);
       ca.transform.localScale = new Vector3(1f, 1f);
       var caSprite = ca.AddComponent<SpriteRenderer>();
       caSprite.sprite = ModAPI.LoadSprite("image/Smokertobacco.png");
       ca.GetComponent<SpriteRenderer>().sortingLayerName = "Middle";
       ca.AddComponent<UseEventTrigger>().Action = () => {
       caSprite.sprite = ModAPI.LoadSprite("none.png");
      };


      person.SetBodyTextures(skin, flesh, bone, 1);
      person.SetBruiseColor(255, 255, 255);
      person.SetSecondBruiseColor(204, 204, 204);
      person.SetThirdBruiseColor(255, 255, 255);
      person.SetBloodColour(204, 204, 204);
      person.SetRottenColour(255, 255, 255);



             }
          }
        }
  );


ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Kokutou Yoru", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Yoru is one of the strongest swords in the world, ranked as one of the 12 Supreme Grade swords. It is a Black Blade that is currently owned by Dracule Mihawk, the Strongest Swordsman in the World.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/KokutouYoruthumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Kokutou Yoru.png", 4f);
            Instance.gameObject.AddComponent<guraguranomi>();



            Instance.FixColliders();

            Instance.GetComponent<PhysicalBehaviour>().Charge = 0f;

            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;


            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
            {
            ModAPI.LoadSound("Sound/haki sound.mp3"),
            };




              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
                    };

                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);
                    };

        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Knife"), //item to derive from
        NameOverride = "Kogatana", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Dracule Mihawk's Meal Tools or Dagger.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Kogatana thumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Kogatana.png", 4f);
                                        Instance.FixColliders();
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Flintlock Pistol"),
        NameOverride = "Marine Rifles",
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Marine Rifles",
        CategoryOverride = ModAPI.FindCategory("One Piece pack"),
        ThumbnailOverride = ModAPI.LoadSprite("image/MarineRiflesthumbnail.png"),
        AfterSpawn = (Instance) =>
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/MarineRifles.png");//This line gets the component of the SpriteRenderer and overrides it by looking in the files. The 2f is the scale of the sprite.

            //Colliders

            foreach (var c in Instance.GetComponents<Collider2D>())
            {
                GameObject.Destroy(c);
            }

            var stock = Instance.AddComponent<BoxCollider2D>();
            stock.offset = new Vector2(0.544f, 0.056f);
            stock.size = new Vector2(1.196f, 0.091f);

            var main = Instance.AddComponent<BoxCollider2D>();
            main.offset = new Vector2(-0.183f, 0.029f);
            main.size = new Vector2(0.256f, 0.143f);

            var barrel = Instance.AddComponent<BoxCollider2D>();
            barrel.offset = new Vector2(-0.467f, -0.034f);
            barrel.size = new Vector2(0.312f, 0.157f);



            //Firearm
            Instance.GetComponent<FirearmBehaviour>().barrelPosition = new Vector2(1.1433f, 0.0833f);
            Instance.GetComponent<FirearmBehaviour>().InitialInaccuracy = 0.03f;
            var customCartridge = UnityEngine.Object.Instantiate(Instance.GetComponent<FirearmBehaviour>().Cartridge);
            customCartridge.Recoil *= 1.2f;
            customCartridge.Damage *= 1.2f;
            customCartridge.ImpactForce *= 1.2f;
            Instance.GetComponent<FirearmBehaviour>().Cartridge = customCartridge;


            ModAPI.KeepExtraObjects();
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Revolver"),
        NameOverride = "Doflamignos gun",
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "There's nothing like lead bullets in execution.",
        CategoryOverride = ModAPI.FindCategory("One Piece pack"),
        ThumbnailOverride = ModAPI.LoadSprite("image/Doflamingogunthum.png"),
        AfterSpawn = (Instance) =>
        {
Instance.GetComponent<FirearmBehaviour>().barrelPosition = new Vector2(0.4f, 0.0833f);
          Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("image/Doflamingogun.png", 2f);
          var firearm = Instance.GetComponent<FirearmBehaviour>();
          Cartridge customCartridge = ModAPI.FindCartridge("9mm");
          customCartridge.name = "9×18mm Makarov";
          customCartridge.Damage *= 100f;
          customCartridge.StartSpeed *= 2f;
          customCartridge.PenetrationRandomAngleMultiplier *= 0.5f;
          customCartridge.Recoil *= 22f;
          customCartridge.ImpactForce *= 10f;
          firearm.Cartridge = customCartridge;
          Instance.FixColliders();

firearm.ShotSounds = new AudioClip[]
{
    ModAPI.LoadSound("Sound/Doflamingogunsound.mp3"),
};


        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Rod"), //item to derive from
        NameOverride = "Smoker jitte", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "The Nanashaku Jitte is Smoker's primary weapon.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Nanashaku Jitte.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.gameObject.AddComponent<Busoshoku>();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Jitte.png", 2.8f);
            Instance.FixColliders();
            Instance.AddComponent<Pruner>();
            Instance.GetComponent<Pruner>().PruneOn = ModAPI.LoadSprite("Image/Jittehakiskin.png", 2.8f);
            Instance.GetComponent<Pruner>().PruneOff = ModAPI.LoadSprite("Image/Jitte.png", 2.8f);

            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;

            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
            {
            ModAPI.LoadSound("Sound/haki sound.mp3"),
            };


            Instance.FixColliders();

              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
                    };

                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);
                    };
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Enma", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Enma is one of the 21 Great Grade swords. It was once wielded by Kozuki Oden alongside his other blade, Ame no Habakiri, and both swords were the only weapons (until the present day) ever to injure Kaido.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Enmathumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {

            Instance.gameObject.AddComponent<Busoshoku>();
            Instance.gameObject.AddComponent<Haoshoku>();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Enma.png", 2.8f);
            Instance.FixColliders();
            Instance.AddComponent<Pruner>();
            Instance.GetComponent<Pruner>().PruneOn = ModAPI.LoadSprite("Image/Enmahakiskin.png", 2.8f);
            Instance.GetComponent<Pruner>().PruneOff = ModAPI.LoadSprite("Image/Enma.png", 2.8f);
            Instance.FixColliders();
            Instance.GetComponent<PhysicalBehaviour>().Charge = 0f;
            Instance.FixColliders();


            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;




            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
            {
            ModAPI.LoadSound("Sound/haki sound.mp3"),
            };


            Instance.FixColliders();

              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
                    };

                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);





                    };
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Ame no Habakiri", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Ame no Habakiri is one of the 21 Great Grade swords. It was once wielded by Kozuki Oden alongside his other blade, Enma, and both swords were the only weapons (until the present day) ever to injure Kaido.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Amenohabakirithumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {

            Instance.gameObject.AddComponent<Busoshoku>();
            Instance.gameObject.AddComponent<Haoshoku>();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Amenohabakiri.png", 2.8f);
            Instance.FixColliders();
            Instance.AddComponent<Pruner>();
            Instance.GetComponent<Pruner>().PruneOn = ModAPI.LoadSprite("Image/Amenohabakirihakiskin.png", 2.8f);
            Instance.GetComponent<Pruner>().PruneOff = ModAPI.LoadSprite("Image/Amenohabakiri.png", 2.8f);
            Instance.FixColliders();
            Instance.GetComponent<PhysicalBehaviour>().Charge = 0f;
            Instance.FixColliders();


            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;




            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
            {
            ModAPI.LoadSound("Sound/haki sound.mp3"),
            };


            Instance.FixColliders();

              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
                    };

                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);
                    };
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Ace", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Ace is a cutlass that was owned and wielded by the Pirate King Gol D. Roger, serving as his trademark weapon. It ranks as one of the 12 Supreme Grade Meito.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Acethumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.gameObject.AddComponent<Haoshoku>();

            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Ace.png", 3.7f);
            Instance.FixColliders();
            Instance.AddComponent<Pruner>();
            Instance.GetComponent<Pruner>().PruneOn = ModAPI.LoadSprite("Image/Acehakiskin.png", 3.7f);
            Instance.GetComponent<Pruner>().PruneOff = ModAPI.LoadSprite("Image/Ace.png", 3.7f);


            UseEventTrigger useEventTrigger0 = Instance.gameObject.AddComponent<UseEventTrigger>();
            useEventTrigger0.Event = new UnityEvent();
            useEventTrigger0.Event.AddListener(delegate ()
             {
               GameObject Projectile = GameObject.Instantiate(ModAPI.FindSpawnable("kamusari").Prefab);
               CatalogBehaviour.PerformMod(ModAPI.FindSpawnable("kamusari"), Projectile);

               Projectile.transform.localScale = Instance.transform.localScale;
               
               Projectile.transform.rotation = Instance.transform.rotation;
               Projectile.transform.eulerAngles += new Vector3(0, 0, 0);
               Projectile.gameObject.GetComponent<PhysicalBehaviour>().SpawnSpawnParticles = false;
               Projectile.transform.position = Instance.transform.position + (Instance.transform.right * 1f * Mathf.Sign(Instance.transform.localScale.x));
               Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(((Instance.transform.localScale.x >= 0) ? Instance.transform.right : -Instance.transform.right) * 5000f);
               Destroy(Projectile, 0.900f);

            });

            var trailrenderer = Instance.gameObject.AddComponent<TrailRenderer>();
            trailrenderer.startWidth = 0.5f;
            trailrenderer.endWidth = 0.5f;
            trailrenderer.time = 0.2f;
            trailrenderer.startColor = new Color32(255, 255, 255, 255);
            trailrenderer.endColor = new Color32(255, 255, 255, 255);
            Material mat = new Material(ModAPI.FindMaterial("Sprites-Default"));
            mat.SetTexture("_MainTex", ModAPI.LoadTexture("image/haoshock.png"));
            trailrenderer.material = mat;
            trailrenderer.sortingOrder = Instance.GetComponent<SpriteRenderer>().sortingOrder = 1;
            trailrenderer.enabled = false;

            Instance.gameObject.AddComponent<UseEventTrigger>().Action = () =>
                {
                    trailrenderer.enabled = !trailrenderer.enabled;
                };

            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;




            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
            {
            ModAPI.LoadSound("Sound/haki sound.mp3"),
            };


            Instance.FixColliders();

              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {

                    };


                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);
                    };

        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Murakumogiri", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Murakumogiri is a naginata and one of the 12 Supreme Grade swords,It is a weapon used by the world's best man Edward Newgate.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Murakumogirithumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.gameObject.AddComponent<Busoshoku>();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Murakumogiri.png", 5f);
            Instance.FixColliders();
            Instance.AddComponent<Pruner>();
            Instance.GetComponent<Pruner>().PruneOn = ModAPI.LoadSprite("Image/Murakumogirihakiskin2.png", 5f);
            Instance.GetComponent<Pruner>().PruneOff = ModAPI.LoadSprite("Image/Murakumogiri.png", 5f);

            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;

            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
            {
            ModAPI.LoadSound("Sound/haki sound.mp3"),
            };


            Instance.FixColliders();

              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
                    };

                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);
                    };

        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Issho Sword", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Sword of Admiral Issho.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/isshopswordthumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.gameObject.AddComponent<Busoshoku>();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Issho Sword.png", 3.7f);
            Instance.FixColliders();
            Instance.AddComponent<Pruner>();
            Instance.GetComponent<Pruner>().PruneOn = ModAPI.LoadSprite("Image/Issho Swordhakiskin.png", 3.7f);
            Instance.GetComponent<Pruner>().PruneOff = ModAPI.LoadSprite("Image/Issho Sword.png", 3.7f);

            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;




            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
            {
            ModAPI.LoadSound("Sound/haki sound.mp3"),
            };




              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
                    };

                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);
                    };

                                        Instance.gameObject.AddComponent<Busoshoku>();

        }
    }
);


ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Soul Solid", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Soul Solid is the name of Brook's cane sword.Since he only gave the name of the sword after the timeskip, it is unknown if his sword always carried this name.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Soul Solidthumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Soul Solid.png", 3.7f);
                                        Instance.FixColliders();
                                        Instance.gameObject.AddComponent<Busoshoku>();

        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Rod"), //item to derive from
        NameOverride = "Sabo's pipe", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Sabo's pipe.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Sabo's pipethumbnamil.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.gameObject.AddComponent<Busoshoku>();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Sabo's pipe.png", 3.8f);
            Instance.FixColliders();
            Instance.AddComponent<Pruner>();
            Instance.GetComponent<Pruner>().PruneOn = ModAPI.LoadSprite("Image/Sabo's pipehakiskin.png", 3.8f);
            Instance.GetComponent<Pruner>().PruneOff = ModAPI.LoadSprite("Image/Sabo's pipe.png", 3.8f);

            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;




            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
            {
            ModAPI.LoadSound("Sound/haki sound.mp3"),
            };


            Instance.FixColliders();

              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
                    };

                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);
                    };

        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Shusui", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Shusui is one of the 21 Great Grade swords and a Black Sword/Blade, It boasts tremendous durability.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Shusuithumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.gameObject.AddComponent<Busoshoku>();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Shusui.png", 4.5f);
            Instance.FixColliders();
            Instance.AddComponent<Pruner>();
            Instance.GetComponent<Pruner>().PruneOn = ModAPI.LoadSprite("Image/Shusuihakiskin.png", 4.5f);
            Instance.GetComponent<Pruner>().PruneOff = ModAPI.LoadSprite("Image/Shusui.png", 4.5f);

            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;


            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
            {
            ModAPI.LoadSound("Sound/haki sound.mp3"),
            };


            Instance.FixColliders();

              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
                    };

                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);
                    };
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Enma Z", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Enma is one of the 21 Great Grade swords, currently in the possession of Roronoa Zoro as one of his three blades.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Enmazthumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {


            Instance.gameObject.AddComponent<Busoshoku>();
            Instance.gameObject.AddComponent<Haoshoku>();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Enma Z.png", 4.5f);
            Instance.FixColliders();
            Instance.AddComponent<Pruner>();
            Instance.GetComponent<Pruner>().PruneOn = ModAPI.LoadSprite("Image/Enma Zhakiskin.png", 4.5f);
            Instance.GetComponent<Pruner>().PruneOff = ModAPI.LoadSprite("Image/Enma Z.png", 4.5f);

            Instance.GetComponent<PhysicalBehaviour>().Charge = 0f;
            Instance.FixColliders();
            UseEventTrigger useEventTrigger = Instance.AddComponent<UseEventTrigger>();
            useEventTrigger.Event = new UnityEvent();
            useEventTrigger.Event.AddListener(delegate ()
            {
            Instance.GetComponent<PhysicalBehaviour>().Charge = 2000f;
            });

            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;




            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
            {
            ModAPI.LoadSound("Sound/haki sound.mp3"),
            };


            Instance.FixColliders();

              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
                    };

                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);





                    };
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Wado Ichimonji", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "The Wado Ichimonji is a sword of great personal importance to Roronoa Zoro, and it once belonged to Kuina and her family. It is also one of the 21 Great Grade swords.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Wado Ichimonjithumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.gameObject.AddComponent<Busoshoku>();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Wado Ichimonji.png", 4.5f);
            Instance.FixColliders();
            Instance.AddComponent<Pruner>();
            Instance.GetComponent<Pruner>().PruneOn = ModAPI.LoadSprite("Image/Wado Ichimonjihakiskin.png", 4.5f);
            Instance.GetComponent<Pruner>().PruneOff = ModAPI.LoadSprite("Image/Wado Ichimonji.png", 4.5f);

            Instance.GetComponent<PhysicalBehaviour>().InitialMass = 0.01f;
            Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = 0.01f;
            Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = 0.01f;

            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;




            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
            {
            ModAPI.LoadSound("Sound/haki sound.mp3"),
            };


            Instance.FixColliders();

              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
                    };

                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);
                    };
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Sandai Kitetsu", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "The Sandai Kitetsu is one of the Grade swords. Like all of its predecessor Kitetsu swords, this one is said to be cursed. It is one of Tenguyama Hitetsu's creations.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Sandai Kitetsuthumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.gameObject.AddComponent<Busoshoku>();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Sandai Kitetsu.png", 4.5f);
            Instance.FixColliders();
            Instance.AddComponent<Pruner>();
            Instance.GetComponent<Pruner>().PruneOn = ModAPI.LoadSprite("Image/Sandai Kitetsuhakiskin.png", 4.5f);
            Instance.GetComponent<Pruner>().PruneOff = ModAPI.LoadSprite("Image/Sandai Kitetsu.png", 4.5f);

            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;




            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
            {
            ModAPI.LoadSound("Sound/haki sound.mp3"),
            };


            Instance.FixColliders();

              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
                    };

                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);
                    };

        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Kikoku", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Kikoku is the name of Trafalgar Law's sword. It is a cursed sword, though is not a ranked blade.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Kikokuthumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Kikoku.png", 4.5f);
                                        Instance.FixColliders();
                                        Instance.gameObject.AddComponent<Busoshoku>();
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Gryphon", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "The Sword of Shanks, one of the Four Emperors,Gryphon is a durable and powerful sword.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Gryphonthumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.gameObject.AddComponent<Busoshoku>();
            Instance.gameObject.AddComponent<Haoshoku>();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Gryphon.png", 3.8f);
            Instance.FixColliders();
            Instance.AddComponent<Pruner>();
            Instance.GetComponent<Pruner>().PruneOn = ModAPI.LoadSprite("Image/Gryphonhakiskin.png", 3.8f);
            Instance.GetComponent<Pruner>().PruneOff = ModAPI.LoadSprite("Image/Gryphon.png", 3.8f);
            Instance.GetComponent<PhysicalBehaviour>().Charge = 0f;

            UseEventTrigger useEventTrigger = Instance.AddComponent<UseEventTrigger>();
            useEventTrigger.Event = new UnityEvent();
            useEventTrigger.Event.AddListener(delegate ()
            {
            Instance.GetComponent<PhysicalBehaviour>().Charge = 2000f;
            });

            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;




            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
            {
            ModAPI.LoadSound("Sound/haki sound.mp3"),
            };


            Instance.FixColliders();

              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
                    };

                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);
                    };
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Murakumogiri E", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Murakumogiri is a naginata and one of the 12 Supreme Grade swords,It is a weapon used by the world's best man Edward Newgate.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Murakumogirithumbnail E.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.gameObject.AddComponent<Busoshoku>();
            Instance.gameObject.AddComponent<Haoshoku>();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Murakumogiri E.png", 1.8f);
            Instance.FixColliders();
            Instance.AddComponent<Pruner>();
            Instance.GetComponent<Pruner>().PruneOn = ModAPI.LoadSprite("Image/Murakumogirihakiskin.png", 1.8f);
            Instance.GetComponent<Pruner>().PruneOff = ModAPI.LoadSprite("Image/Murakumogiri E.png", 1.8f);
            Instance.GetComponent<PhysicalBehaviour>().Charge = 0f;

            UseEventTrigger useEventTrigger = Instance.AddComponent<UseEventTrigger>();
            useEventTrigger.Event = new UnityEvent();
            useEventTrigger.Event.AddListener(delegate ()
            {
            Instance.GetComponent<PhysicalBehaviour>().Charge = 2000f;
            });

            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;




            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
            {
            ModAPI.LoadSound("Sound/haki sound.mp3"),
            };


            Instance.FixColliders();

              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
                    };

                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);
                    };

        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"),
        NameOverride = "Hassaikai",
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Kaido's great weapon.",
        CategoryOverride = ModAPI.FindCategory("One Piece pack"),
        ThumbnailOverride = ModAPI.LoadSprite("Image/Hassaikaithumbnail.png"),
        AfterSpawn = (Instance) =>
        {
            Instance.gameObject.AddComponent<Busoshoku>();
            Instance.gameObject.AddComponent<Haoshoku>();
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Hassaikai.png", 1.1f);
            Instance.FixColliders();
            Instance.AddComponent<Pruner>();
            Instance.GetComponent<Pruner>().PruneOn = ModAPI.LoadSprite("Image/Hassaikaihakiskin.png", 1.1f);
            Instance.GetComponent<Pruner>().PruneOff = ModAPI.LoadSprite("Image/Hassaikai.png", 1.1f);
            Instance.GetComponent<PhysicalBehaviour>().InitialMass = 10f;
            Instance.GetComponent<PhysicalBehaviour>().TrueInitialMass = 10f;
            Instance.GetComponent<PhysicalBehaviour>().rigidbody.mass = 10f;

            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;




            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
       {
            ModAPI.LoadSound("Thunder Bagua.mp3"),
       };


            Instance.FixColliders();

              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
                    };

                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);
                    };

        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Yamato's kanabo", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Yamato's kanabo, Yamato wields a giant kanabo club much like Kaidou, though hers is studded and more slender, while Kaidou's is spiked and a bit thicker.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Yamato’s kanabothumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Yamato’s kanabo.png", 3.4f);
            Instance.gameObject.AddComponent<Haoshoku>();
            Instance.FixColliders();

            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;




            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
            {
            ModAPI.LoadSound("Sound/Thunder Bagua2.mp3"),
            };


            Instance.FixColliders();

              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
                    };

                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);
                    };


        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Mogura", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Mogura is a trident, with its three prongs tightly together. The middle prong is a full spear-shape, while the two on the sides are half-blades.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Mogurathumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Mogu.png", 2.5f);
                                        Instance.FixColliders();
                                        Instance.gameObject.AddComponent<Busoshoku>();

        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Napoleon P", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Napoleon the Bicorne is a homie taking the form of a bicorne hat that is worn by Big Mom. It can also become a sword that Big Mom uses in combat.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Napoleon Pthumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Napoleon P.png", 5f);
                                        Instance.FixColliders();
                                        Instance.gameObject.AddComponent<Busoshoku>();
            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;




            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
       {
            ModAPI.LoadSound("napoleon bgm.mp3"),
      };


            Instance.FixColliders();

            Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
               };

        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Napoleon B", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Kaido's great weapon.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Napoleon Bthumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Napoleon B.png", 1.3f);
            Instance.FixColliders();
            Instance.gameObject.AddComponent<Haoshoku>();
            Instance.gameObject.AddComponent<Busoshoku>();


            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;




            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
       {
            ModAPI.LoadSound("napoleon bgm.mp3"),
       };


            Instance.FixColliders();

              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
                    };

                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);
                    };

        }
    }
);
ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Oto", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Cherry Ten,Oto and Kogarashi are a pair of double-edged swords wielded by Golden Lion Shiki.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Otothumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Oto.png", 2.8f);
            Instance.gameObject.AddComponent<Busoshoku>();
            Instance.FixColliders();


            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;




            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
            {
            ModAPI.LoadSound("Sound/haki sound.mp3"),
            };


            Instance.FixColliders();

              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
                    };

                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);
                    };
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Kogarashi", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Winter Wind,Oto and Kogarashi are a pair of double-edged swords wielded by Golden Lion Shiki.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Kogarashithumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Kogarashi.png", 2.8f);
            Instance.gameObject.AddComponent<Busoshoku>();
            Instance.FixColliders();


            AudioSource AS = Instance.AddComponent<AudioSource>();
                                                    AS.minDistance = 1;
                                                    AS.maxDistance = 5;




            int index = 0;
            AudioClip[] AudioData = new AudioClip[]
            {
            ModAPI.LoadSound("Sound/haki sound.mp3"),
            };


            Instance.FixColliders();

              Instance.AddComponent<UseEventTrigger>().Action = () =>
                {
                    AS.clip = AudioData[index];
                    AS.Play();
                    };

                    Instance.AddComponent<UseEventTrigger>().Action = () => {
                      //spawn an effect by the name of "Spark" at the transform position
                      ModAPI.CreateParticleEffect("Spark", Instance.transform.position);
                    };
        }
    }
);

ModAPI.Register(
    new Modification()
    {
        OriginalItem = ModAPI.FindSpawnable("Spear"), //item to derive from
        NameOverride = "Yubashiri", //new item name with a suffix to assure it is globally unique
        NameToOrderByOverride = "Z1",
        DescriptionOverride = "Yubashiri was one of the 50 Skillful Grade swords. Roronoa Zoro obtained this sword for free from Ipponmatsu.", //new item description
        CategoryOverride = ModAPI.FindCategory("One Piece pack"), //new item category
        ThumbnailOverride = ModAPI.LoadSprite("Image/Yubashirithumbnail.png"), //new item thumbnail (relative path)
        AfterSpawn = (Instance) => //all code in the AfterSpawn delegate will be executed when the item is spawned
        {
            Instance.GetComponent<SpriteRenderer>().sprite = ModAPI.LoadSprite("Image/Yubashiri.png", 4.5f);
                                        Instance.FixColliders();
                                        Instance.gameObject.AddComponent<Busoshoku>();
        }
    }
);

       }


       public static void OnLoad()
       {
          powersprites.pellet = ModAPI.LoadSprite("image/meteoric volcano.png", 5f);

          powersprites.py = ModAPI.LoadSprite("image/python.png");

          powersprites.PadCannon = ModAPI.LoadSprite("image/ThrustPadCannon.png");

          powersprites.con = ModAPI.LoadSprite("image/vibration ball.png", 80f);

          powersprites.Bomber1 = ModAPI.LoadSprite("image/Bomber.png", 80f);

          powersprites.bhole = ModAPI.LoadSprite("image/bhole.png", 80f);

          powersprites.Opecon = ModAPI.LoadSprite("image/Opecon.png", 70f);

          powersprites.hao2 = ModAPI.LoadSprite("image/hao2.png", 10f);

          powersprites.jikicon = ModAPI.LoadSprite("image/jikicon.png", 30f);

          powersprites.yomicon = ModAPI.LoadSprite("image/yomicon.png", 70f);

       }

       public class Brighten : MonoBehaviour
       {
           public bool Activated = false;
           public GameObject Paint = new GameObject("Lighter");
           public Color32 Colour;
           public float TargetCharge = 0f;
           public Sprite PaintSprite;
           public LightSprite Light;

           public void UpdateGlow()
           {
               if(Activated == true)
               {
                   Paint.GetComponent<SpriteRenderer>().color = Colour;
               }
               else if(Activated == false)
               {

                   Paint.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 0);
               }
           }

           void Start()
           {
               Paint.transform.parent = gameObject.transform;
               Paint.transform.rotation = gameObject.transform.rotation;
               Paint.transform.localPosition = new Vector3(0f, 0f);
               Paint.transform.localScale = new Vector3(1f, 1f);

               var Sprite = Paint.GetOrAddComponent<SpriteRenderer>();
               Sprite.sprite = PaintSprite;
               Sprite.material = ModAPI.FindMaterial("Sprites-Default");
               Sprite.GetComponent<SpriteRenderer>().sortingLayerName = "thickness";
               Sprite.color = new Color32(1, 1, 1, 1);

               Sprite.sortingOrder = gameObject.GetComponent<SpriteRenderer>().sortingOrder = +50;

               Light = ModAPI.CreateLight(gameObject.transform, new Color32(Colour.r, Colour.g, Colour.b, 255), 3f, 0f);
               UpdateGlow();
           }

           void Use()
           {
               Activated = !Activated;
               UpdateGlow();
           }

           void Update()
           {
               if(Activated == true)
               {
               }
               else
               {
               }
           }


       }

       public class Pruner : MonoBehaviour
       {
           public Sprite PruneOn;
           public Sprite PruneOff;

           bool IsOn = false;

           public void Start()
           {

               gameObject.AddComponent<UseEventTrigger>().Action = () =>
               {
                   if (IsOn)
                   {
                       IsOn = false;
                       GetComponent<SpriteRenderer>().sprite = PruneOff;

                   }
                   else
                   {
                       IsOn = true;
                       GetComponent<SpriteRenderer>().sprite = PruneOn;
                   }
               };
           }

           public void Update()
           {

           }
           public void OnCollisionEnter2D(Collision2D other)
           {
               if (other.gameObject.GetComponent<LimbBehaviour>())
               {
                   if (IsOn)
                   {

                   }
               }

           }

       }

       public class MeraMeranoMi : MonoBehaviour
       {
       AudioClip Repulsor = ModAPI.LoadSound("Sound/Eatrug.mp3");
           void OnCollisionEnter2D(Collision2D collision)
           {
               if (collision.gameObject.name == "Head") {

                   foreach (LimbBehaviour limb in collision.gameObject.transform.parent.GetComponent<PersonBehaviour>().Limbs) {
                       AudioSource audio = limb.gameObject.AddComponent<AudioSource>();
                       audio.spatialBlend = 1;
                       audio.PlayOneShot(Repulsor);
                       limb.gameObject.AddComponent<Firebeh>();
                       limb.gameObject.AddComponent<Firebeh2>();
                       limb.gameObject.AddComponent<strongrege>();
                       limb.BreakingThreshold *= 100f;

                       limb.Person.SetBruiseColor(255, 153, 000);
                       limb.Person.SetSecondBruiseColor(255, 051, 0000);
                       limb.Person.SetThirdBruiseColor(255, 000, 000);
                       limb.Person.SetBloodColour(255, 102, 000);
                       limb.Person.SetRottenColour(000, 000, 000);
                   };

                   Destroy(this.gameObject);
               };
           }
       }

       public class SunaSunanoMi : MonoBehaviour
       {
       AudioClip Repulsor = ModAPI.LoadSound("Sound/Eatrug.mp3");
           void OnCollisionEnter2D(Collision2D collision)
           {
               if (collision.gameObject.name == "Head") {

                   foreach (LimbBehaviour limb in collision.gameObject.transform.parent.GetComponent<PersonBehaviour>().Limbs) {
                       AudioSource audio = limb.gameObject.AddComponent<AudioSource>();
                       audio.spatialBlend = 1;
                       audio.PlayOneShot(Repulsor);
                       limb.gameObject.AddComponent<Barchan>();
                       limb.gameObject.AddComponent<strongrege>();

                       limb.Person.SetBruiseColor(120, 051, 000);
                       limb.Person.SetSecondBruiseColor(153, 102, 051);
                       limb.Person.SetThirdBruiseColor(255, 000, 000);
                       limb.Person.SetBloodColour(204, 153, 000);
                       limb.Person.SetRottenColour(000, 000, 000);
                       limb.BreakingThreshold *= 100f;
                   };

                   Destroy(this.gameObject);
               };
           }
       }

       public class HieHienoMi : MonoBehaviour
       {
       AudioClip Repulsor = ModAPI.LoadSound("Sound/Eatrug.mp3");
           void OnCollisionEnter2D(Collision2D collision)
           {
               if (collision.gameObject.name == "Head") {

                   foreach (LimbBehaviour limb in collision.gameObject.transform.parent.GetComponent<PersonBehaviour>().Limbs) {
                       AudioSource audio = limb.gameObject.AddComponent<AudioSource>();
                       audio.spatialBlend = 1;
                       audio.PlayOneShot(Repulsor);
                       limb.gameObject.AddComponent<ice2>();
                       limb.gameObject.AddComponent<strongrege>();

                       limb.gameObject.AddComponent<Ice>();
                       limb.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Ice");
                       limb.BreakingThreshold *= 100f;
                       limb.Person.SetBruiseColor(255, 255, 255);
                       limb.Person.SetSecondBruiseColor(000, 000, 153);
                       limb.Person.SetThirdBruiseColor(255, 255, 255);
                       limb.Person.SetBloodColour(000, 000, 102);
                       limb.Person.SetRottenColour(000, 000, 000);


                   };

                   Destroy(this.gameObject);
               };
           }
       }

       public class MaguMagunoMi : MonoBehaviour
       {
       AudioClip Repulsor = ModAPI.LoadSound("Sound/Eatrug.mp3");
           void OnCollisionEnter2D(Collision2D collision)
           {

               if (collision.gameObject.name == "Head") {

                   foreach (LimbBehaviour limb in collision.gameObject.transform.parent.GetComponent<PersonBehaviour>().Limbs) {
                       AudioSource audio = limb.gameObject.AddComponent<AudioSource>();
                       audio.spatialBlend = 1;
                       audio.PlayOneShot(Repulsor);
                       limb.gameObject.AddComponent<Crush>();
                       limb.gameObject.AddComponent<Firebeh>();
                       limb.gameObject.AddComponent<mg1>();
                       limb.gameObject.AddComponent<strongrege>();

                       limb.BreakingThreshold *= 100f;
                       limb.Person.SetBruiseColor(153, 000, 000);
                       limb.Person.SetSecondBruiseColor(204, 000, 000);
                       limb.Person.SetThirdBruiseColor(204, 000, 000);
                       limb.Person.SetBloodColour(255, 000, 000);
                       limb.Person.SetRottenColour(102, 000, 000);



                   };

                   Destroy(this.gameObject);
               };
           }
       }

       public class GoroGoronoMi : MonoBehaviour
       {
       AudioClip Repulsor = ModAPI.LoadSound("Sound/Eatrug.mp3");
           void OnCollisionEnter2D(Collision2D collision)
           {
               if (collision.gameObject.name == "Head") {

                   foreach (LimbBehaviour limb in collision.gameObject.transform.parent.GetComponent<PersonBehaviour>().Limbs) {
                       AudioSource audio = limb.gameObject.AddComponent<AudioSource>();
                       audio.spatialBlend = 1;
                       audio.PlayOneShot(Repulsor);
                       limb.gameObject.AddComponent<Lightning>();
                       limb.gameObject.AddComponent<spark>();
                       limb.gameObject.AddComponent<strongrege>();

                       limb.BreakingThreshold *= 100f;
                       limb.Person.SetBruiseColor(000, 255, 255);
                       limb.Person.SetSecondBruiseColor(000, 051, 204);
                       limb.Person.SetThirdBruiseColor(51, 051, 255);
                       limb.Person.SetBloodColour(255, 255, 255);
                       limb.Person.SetRottenColour(000, 000, 000);


                   };

                   Destroy(this.gameObject);
               };
           }
       }

       public class PikaPikanoMi : MonoBehaviour
       {
       AudioClip Repulsor = ModAPI.LoadSound("Sound/Eatrug.mp3");
           void OnCollisionEnter2D(Collision2D collision)
           {
               if (collision.gameObject.name == "Head") {

                   foreach (LimbBehaviour limb in collision.gameObject.transform.parent.GetComponent<PersonBehaviour>().Limbs) {
                       AudioSource audio = limb.gameObject.AddComponent<AudioSource>();
                       audio.spatialBlend = 1;
                       audio.PlayOneShot(Repulsor);
                       limb.gameObject.AddComponent<GunBeh>();
                       limb.gameObject.AddComponent<strongrege>();

                       limb.BreakingThreshold *= 100f;
                       limb.Person.SetBruiseColor(255, 255, 000);
                       limb.Person.SetSecondBruiseColor(255, 255, 102);
                       limb.Person.SetThirdBruiseColor(255, 255, 153);
                       limb.Person.SetBloodColour(255, 255, 204);
                       limb.Person.SetRottenColour(000, 000, 000);


                   };

                   Destroy(this.gameObject);
               };
           }
       }

       public class YamiYaminoMi : MonoBehaviour
       {
       AudioClip Repulsor = ModAPI.LoadSound("Sound/Eatrug.mp3");
           void OnCollisionEnter2D(Collision2D collision)
           {
               if (collision.gameObject.name == "Head") {

                   foreach (LimbBehaviour limb in collision.gameObject.transform.parent.GetComponent<PersonBehaviour>().Limbs) {
                       AudioSource audio = limb.gameObject.AddComponent<AudioSource>();
                       audio.spatialBlend = 1;
                       audio.PlayOneShot(Repulsor);
                       limb.gameObject.AddComponent<yaminomi>();
                       limb.gameObject.AddComponent<strongrege>();

                       limb.BreakingThreshold *= 100f;
                       limb.Person.SetBruiseColor(000, 000, 000);
                       limb.Person.SetSecondBruiseColor(051, 051, 051);
                       limb.Person.SetThirdBruiseColor(051, 051, 051);
                       limb.Person.SetBloodColour(000, 000, 000);
                       limb.Person.SetRottenColour(000, 000, 000);


                   };

                   Destroy(this.gameObject);
               };
           }
       }
       public class GuraGuranoMi : MonoBehaviour
       {
       AudioClip Repulsor = ModAPI.LoadSound("Sound/Eatrug.mp3");
       AudioClip Repulsor2 = ModAPI.LoadSound("Sound/guragurarug.mp3");
           void OnCollisionEnter2D(Collision2D collision)
           {

               if (collision.gameObject.name == "Head") {
                   foreach (LimbBehaviour limb in collision.gameObject.transform.parent.GetComponent<PersonBehaviour>().Limbs) {
                       AudioSource audio = limb.gameObject.AddComponent<AudioSource>();
                       audio.spatialBlend = 1;
                       audio.PlayOneShot(Repulsor);
                       UseEventTrigger useEventTrigger = limb.gameObject.AddComponent<UseEventTrigger>();
                       useEventTrigger.Event = new UnityEvent();
                       useEventTrigger.Event.AddListener(delegate ()
                        {
                          audio.spatialBlend = 1;
                         audio.PlayOneShot(Repulsor2);
                       });
                       limb.gameObject.AddComponent<guraguranomi>();
                       limb.gameObject.AddComponent<strongrege>();

                       limb.BreakingThreshold *= 100f;
                   };

                   Destroy(this.gameObject);
               };
           }
       }

       public class ItoItonoMi : MonoBehaviour
       {
       AudioClip Repulsor = ModAPI.LoadSound("Sound/Eatrug.mp3");
           void OnCollisionEnter2D(Collision2D collision)
           {
               if (collision.gameObject.name == "Head") {

                   foreach (LimbBehaviour limb in collision.gameObject.transform.parent.GetComponent<PersonBehaviour>().Limbs) {
                       AudioSource audio = limb.gameObject.AddComponent<AudioSource>();
                       audio.spatialBlend = 1;
                       audio.PlayOneShot(Repulsor);
                       limb.gameObject.AddComponent<Webs>();
                       limb.gameObject.AddComponent<strongrege>();

                       limb.BreakingThreshold *= 100f;
                       limb.Person.SetBruiseColor(255, 255, 000);
                       limb.Person.SetSecondBruiseColor(255, 255, 102);
                       limb.Person.SetThirdBruiseColor(255, 255, 153);
                       limb.Person.SetBloodColour(255, 255, 204);
                       limb.Person.SetRottenColour(000, 000, 000);
                   };

                   Destroy(this.gameObject);
               };
           }
       }

       public class DokuDokunoMi : MonoBehaviour
       {
       AudioClip Repulsor = ModAPI.LoadSound("Sound/Eatrug.mp3");
           void OnCollisionEnter2D(Collision2D collision)
           {
               if (collision.gameObject.name == "Head") {

                   foreach (LimbBehaviour limb in collision.gameObject.transform.parent.GetComponent<PersonBehaviour>().Limbs) {
                       AudioSource audio = limb.gameObject.AddComponent<AudioSource>();
                       audio.spatialBlend = 1;
                       audio.PlayOneShot(Repulsor);
                       limb.gameObject.AddComponent<Venom>();
                       limb.gameObject.AddComponent<strongrege>();

                       limb.BreakingThreshold *= 100f;
                   };

                   Destroy(this.gameObject);
               };
           }
       }

       public class GomuGomunoMi : MonoBehaviour
       {
       AudioClip Repulsor = ModAPI.LoadSound("Sound/Eatrug.mp3");

           void OnCollisionEnter2D(Collision2D collision)
           {

               if (collision.gameObject.name == "Head") {

                   foreach (LimbBehaviour limb in collision.gameObject.transform.parent.GetComponent<PersonBehaviour>().Limbs) {
                       AudioSource audio = limb.gameObject.AddComponent<AudioSource>();
                       audio.spatialBlend = 1;
                       audio.PlayOneShot(Repulsor);
                       limb.gameObject.AddComponent<UseEventTrigger>().Action = () =>
                       {
                           GameObject Projectile = GameObject.Instantiate(ModAPI.FindSpawnable("gear2fist").Prefab);
                           CatalogBehaviour.PerformMod(ModAPI.FindSpawnable("gear2fist"), Projectile);
                           Projectile.transform.rotation = limb.transform.rotation;
                           Projectile.transform.eulerAngles += new Vector3(0, 0, -90);
                           Projectile.gameObject.GetComponent<PhysicalBehaviour>().SpawnSpawnParticles = false;
                           Projectile.transform.position = limb.transform.position + (-limb.transform.up * 2.1f);
                           Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(Projectile.transform.right * 1000);
                           Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(-Projectile.transform.right * -1000);
                           var col = Projectile.AddComponent<NoCollide>();
                           col.NoCollideSetA = Projectile.GetComponents<Collider2D>();
                           col.NoCollideSetB = limb.GetComponentsInChildren<Collider2D>();
                           Destroy(Projectile, 0.200f);
                       };
                       limb.gameObject.AddComponent<strongrege>();

                       limb.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Rubber");
                       limb.BreakingThreshold *= 100f;
                   };

                   Destroy(this.gameObject);
               };
           }
       }

       public class BomuBomunoMi : MonoBehaviour
       {
       AudioClip Repulsor = ModAPI.LoadSound("Sound/Eatrug.mp3");
           void OnCollisionEnter2D(Collision2D collision)
           {
               if (collision.gameObject.name == "Head") {

                   foreach (LimbBehaviour limb in collision.gameObject.transform.parent.GetComponent<PersonBehaviour>().Limbs) {
                       AudioSource audio = limb.gameObject.AddComponent<AudioSource>();
                       audio.spatialBlend = 1;
                       audio.PlayOneShot(Repulsor);
                       limb.gameObject.AddComponent<bomubomunomi>();
                       limb.gameObject.AddComponent<strongrege>();

                       limb.BreakingThreshold *= 100f;
                   };

                   Destroy(this.gameObject);
               };
           }
       }

       public class OpeOpenoMi : MonoBehaviour
       {
       AudioClip Repulsor = ModAPI.LoadSound("Sound/Eatrug.mp3");
           void OnCollisionEnter2D(Collision2D collision)
           {
               if (collision.gameObject.name == "Head") {

                   foreach (LimbBehaviour limb in collision.gameObject.transform.parent.GetComponent<PersonBehaviour>().Limbs) {
                       AudioSource audio = limb.gameObject.AddComponent<AudioSource>();
                       audio.spatialBlend = 1;
                       audio.PlayOneShot(Repulsor);
                       limb.gameObject.AddComponent<openomi>();
                       limb.gameObject.AddComponent<strongrege>();

                       limb.BreakingThreshold *= 100f;
                   };

                   Destroy(this.gameObject);
               };
           }
       }

       public class JikiJikinoMi : MonoBehaviour
       {
       AudioClip Repulsor = ModAPI.LoadSound("Sound/Eatrug.mp3");
           void OnCollisionEnter2D(Collision2D collision)
           {
               if (collision.gameObject.name == "Head") {

                   foreach (LimbBehaviour limb in collision.gameObject.transform.parent.GetComponent<PersonBehaviour>().Limbs) {
                       AudioSource audio = limb.gameObject.AddComponent<AudioSource>();
                       audio.spatialBlend = 1;
                       audio.PlayOneShot(Repulsor);
                       limb.gameObject.AddComponent<jikinomi>();
                       limb.gameObject.AddComponent<strongrege>();

                       limb.BreakingThreshold *= 100f;
                   };

                   Destroy(this.gameObject);
               };
           }
       }

       public class SubeSubenMi : MonoBehaviour
       {
       AudioClip Repulsor = ModAPI.LoadSound("Sound/Eatrug.mp3");
           void OnCollisionEnter2D(Collision2D collision)
           {
               if (collision.gameObject.name == "Head") {

                   foreach (LimbBehaviour limb in collision.gameObject.transform.parent.GetComponent<PersonBehaviour>().Limbs) {
                       AudioSource audio = limb.gameObject.AddComponent<AudioSource>();
                       audio.spatialBlend = 1;
                       audio.PlayOneShot(Repulsor);
                       limb.GetComponent<PhysicalBehaviour>().Properties = ModAPI.FindPhysicalProperties("Soap");
                       limb.gameObject.AddComponent<strongrege>();

                       limb.BreakingThreshold *= 100f;
                   };

                   Destroy(this.gameObject);
               };
           }
       }

       public class YomiYominoMi : MonoBehaviour
       {
       AudioClip Repulsor = ModAPI.LoadSound("Sound/Eatrug.mp3");
           void OnCollisionEnter2D(Collision2D collision)
           {
               if (collision.gameObject.name == "Head") {

                   foreach (LimbBehaviour limb in collision.gameObject.transform.parent.GetComponent<PersonBehaviour>().Limbs) {
                       AudioSource audio = limb.gameObject.AddComponent<AudioSource>();
                       audio.spatialBlend = 1;
                       audio.PlayOneShot(Repulsor);
                       limb.gameObject.AddComponent<yominomi>();
                       limb.gameObject.AddComponent<strongrege>();

                       limb.BreakingThreshold *= 100f;
                   };
                   Destroy(this.gameObject);
               };
           }
       }

       public class MochiMochinoMi : MonoBehaviour
       {
       AudioClip Repulsor = ModAPI.LoadSound("Sound/Eatrug.mp3");

           void OnCollisionEnter2D(Collision2D collision)
           {

               if (collision.gameObject.name == "Head") {

                   foreach (LimbBehaviour limb in collision.gameObject.transform.parent.GetComponent<PersonBehaviour>().Limbs) {
                       AudioSource audio = limb.gameObject.AddComponent<AudioSource>();
                       audio.spatialBlend = 1;
                       audio.PlayOneShot(Repulsor);
                       limb.gameObject.AddComponent<strongrege>();

                       limb.BreakingThreshold *= 100f;
                       limb.Person.SetBruiseColor(242, 243, 236);
                       limb.Person.SetSecondBruiseColor(242, 243, 236);
                       limb.Person.SetThirdBruiseColor(242, 243, 236);
                       limb.Person.SetBloodColour(242, 243, 236);
                       limb.Person.SetRottenColour(242, 243, 236);
                       limb.gameObject.AddComponent<UseEventTrigger>().Action = () =>
                       {
                           GameObject Projectile = GameObject.Instantiate(ModAPI.FindSpawnable("Donutfist").Prefab);
                           CatalogBehaviour.PerformMod(ModAPI.FindSpawnable("Donutfist"), Projectile);
                           Projectile.transform.rotation = limb.transform.rotation;
                           Projectile.transform.eulerAngles += new Vector3(0, 0, -90);
                           Projectile.gameObject.GetComponent<PhysicalBehaviour>().SpawnSpawnParticles = false;
                           Projectile.transform.position = limb.transform.position + (-limb.transform.up * 3.7f);
                           Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(Projectile.transform.right * 2000);
                           Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(-Projectile.transform.right * -2000);
                           var col = Projectile.AddComponent<NoCollide>();
                           col.NoCollideSetA = Projectile.GetComponents<Collider2D>();
                           col.NoCollideSetB = limb.GetComponentsInChildren<Collider2D>();
                           Destroy(Projectile, 0.200f);
                       };

                   };

                   Destroy(this.gameObject);
               };
           }
       }

       public class HanaHananoMi : MonoBehaviour
       {
       AudioClip Repulsor = ModAPI.LoadSound("Sound/Eatrug.mp3");

           void OnCollisionEnter2D(Collision2D collision)
           {

               if (collision.gameObject.name == "Head") {

                   foreach (LimbBehaviour limb in collision.gameObject.transform.parent.GetComponent<PersonBehaviour>().Limbs) {
                       AudioSource audio = limb.gameObject.AddComponent<AudioSource>();
                       audio.spatialBlend = 1;
                       audio.PlayOneShot(Repulsor);
                       limb.gameObject.AddComponent<strongrege>();

                       limb.BreakingThreshold *= 100f;
                       limb.gameObject.AddComponent<UseEventTrigger>().Action = () =>
                       {
                           GameObject Projectile = GameObject.Instantiate(ModAPI.FindSpawnable("hanafist").Prefab);
                           CatalogBehaviour.PerformMod(ModAPI.FindSpawnable("hanafist"), Projectile);
                           Projectile.transform.rotation = limb.transform.rotation;
                           Projectile.transform.eulerAngles += new Vector3(0, 0, -90);
                           Projectile.gameObject.GetComponent<PhysicalBehaviour>().SpawnSpawnParticles = false;
                           Projectile.transform.position = limb.transform.position + (-limb.transform.up * 1.3f);
                           Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(Projectile.transform.right * 1000);
                           Projectile.GetComponent<Rigidbody2D>().AddRelativeForce(-Projectile.transform.right * -1000);
                           var col = Projectile.AddComponent<NoCollide>();
                           col.NoCollideSetA = Projectile.GetComponents<Collider2D>();
                           col.NoCollideSetB = limb.GetComponentsInChildren<Collider2D>();
                           Destroy(Projectile, 0.200f);
                       };

                   };

                   Destroy(this.gameObject);
               };
           }
       }

       public class LuffyVoice : MonoBehaviour
       {
           public AudioClip PantsFeetSong = ModAPI.LoadSound("beam2.mp3");

           public AudioClip Pain = ModAPI.LoadSound("Lpain.mp3");
           public AudioClip Dead = ModAPI.LoadSound("Sound/luffyrug.mp3");
           public AudioClip sleepp = ModAPI.LoadSound("Lsleepp.mp3");
           public AudioSource audio;
           List<GameObject> Hands = new List<GameObject>();
           bool SetDead = false;
           bool Sleep = false;
           bool Sword = false;
           public void Start()
           {
               GameObject AUdio = new GameObject();
               AUdio.transform.SetParent(transform, false);
               audio = AUdio.gameObject.AddComponent<AudioSource>();
               audio.spatialBlend = 1;
               AUdio.AddComponent<AudioDistortionFilter>().distortionLevel = 0.8f;
               item = GetComponent<LimbBehaviour>();
               foreach (var item in transform.parent.GetComponentsInChildren<GripBehaviour>())
               {
                   Hands.Add(item.gameObject);
               }
           }

           public LimbBehaviour item;
           public void Update()
           {
               if (item.IsConsideredAlive && item.Person.Consciousness > 0.8f)
               {
                   Sleep = false;
                   SetDead = false;
                   if (!(item.Person.ShockLevel > 0) && ((!Sword && audio.clip != PantsFeetSong)))
                   {
                       if (!Sword)
                           audio.clip = PantsFeetSong;


                   }
                   else
                   {
                       if ((item.Person.ShockLevel > 0) && audio.clip != Pain)
                       {
                           audio.clip = Pain;
                           audio.loop = true;
                           audio.Play();
                       }
                   }
               }
               else if (item.Person.Consciousness < 0.8f && !Sleep)
               {
                   audio.Stop();
                   Sleep = true;
                   audio.clip = sleepp;
                   audio.loop = false;
                   audio.Play();
               }
               else if (!item.IsConsideredAlive && !SetDead)
               {
                   SetDead = true;
                   audio.clip = Dead;
                   audio.loop = false;
                   audio.Play();
               }

           }


       }

       public class regenstuffnthing : MonoBehaviour
       {
           public LimbBehaviour limb;
           public bool CanRegen = true;
           public bool CanResurect = false;
           public bool CanBeKnockedOut = true;
           public float RegenSpeed = 2;
           public bool LimbDieOnDismembered = true;

           public void Start()
           {
               limb = GetComponent<LimbBehaviour>();
               StartCoroutine(BaseHeal(limb));
           }

           Coroutine coroutine1;
           Coroutine coroutine2;
           Coroutine coroutine3;
           Coroutine coroutine4;
           Coroutine coroutine5;

           private IEnumerator BaseHeal(LimbBehaviour limb)
           {

               if (CanResurect || (!CanResurect && limb.IsConsideredAlive))
               {
                   while (CanRegen == true && ((LimbDieOnDismembered && !limb.IsDismembered) || !LimbDieOnDismembered))
                   {
                       if (limb.PhysicalBehaviour.OnFire)
                       {
                           limb.CirculationBehaviour.RemoveLiquid(Liquid.GetLiquid("GOHEAL"), 10f);
                           yield return new WaitForSeconds(2f);
                           yield break;
                       }
                       limb.CirculationBehaviour.AddLiquid(Liquid.GetLiquid("GOHEAL"), 1f);
                       yield return new WaitForSeconds(2f);
                   }
               }
           }
       }

       public class GoHeal : LifeSyringe.LifeSerumLiquid
       {
           public GoHeal()
           {
               this.Color = Liquid.GetLiquid("BLOOD").Color;
           }
       }

public class MppManager : MonoBehaviour
    {
        //This class is used to store major stuff through the whole mod - Camdog74


        //This is how we store the power menu icons, we should load them when the game starts
        //but i made it so it loads when an object is spawned. Just how it was made, it works.
        public List<Sprite> PowerIcons = new List<Sprite>();

        //Stores all the snapped people, i made this public so if you have multiple gauntlets, they can all bring back snapped people - Camdog74
        public List<GameObject> SnappedPeople = new List<GameObject>();

        public List<AudioClip> clips = new List<AudioClip>();
    }

public class SuperPowerMarvelPack : MonoBehaviour
    {
        public bool Enabled = true;
        public bool AddToPowerList = true;

        public UseEventTrigger eventTrigger;

        //power info
        public string PowerName = "Power";
        public string Activation = "None";
      

        public string PowerDescription = "Power";

        //other stuff
        public bool CanConsider = false;
        public bool CanBeRemoved = true;

        public virtual void Start()
        {
         



            if (AddToPowerList)
            {

                List<object> PowerInfo = new List<object>();
                //0
              

                //This sends the power to the framework.
                if (GameObject.Find("PowerPackFrameworkManager"))
                    GameObject.Find("PowerPackFrameworkManager").SendMessage("AddNewPowerToMenu", PowerInfo);
            }





        }

        public virtual void DisablePower()
        {
           if(eventTrigger)
            eventTrigger.enabled = false;
            Enabled = false;
        }

        public virtual void EnablePower()
        {

            if(eventTrigger)
            eventTrigger.enabled = true;
            Enabled = true;
        }

        public virtual void RemovePower(bool BigDestroy)
        {

            if (CanBeRemoved)
                StartCoroutine(DestroyTimer());
        }

        public virtual IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(0.15f);
            if (GetComponent<UseEventTrigger>())
            {
                Component.Destroy(GetComponent<UseEventTrigger>());
            }
            Component.Destroy(this);

        }

    }

       public class SlideableHandWeapon : SuperPowerMarvelPack
    {
        public void Awake()
        {
            Activation = "Hand";
        }



        bool CanUse = true;
        public GameObject Claw;
        public GameObject body;
        public Vector3 OgGripPos;
        public bool Retracted = true;
        public bool Scale = false;
        int OgSortinglayer;
        int OgSortingOrder;
        public AudioClip SlideInSound;
        public AudioClip SlideOutSound;
        public AudioSource audio;
        public void SetUpClaw(GameObject Body, GameObject claw)
        {
            body = Body;
            Claw = claw;
            Claw.GetComponent<Collider2D>().enabled = false;
            Claw.transform.localPosition = Vector2.zero;
            OgSortingOrder = Claw.GetComponent<SpriteRenderer>().sortingOrder;
            OgSortinglayer = Claw.GetComponent<SpriteRenderer>().sortingLayerID;
            Claw.SetActive(false);
            audio = body.gameObject.AddComponent<AudioSource>();
            audio.spatialBlend = 1;
        }
        public void Update()
        {
            if (Claw)
            {
                if (!Retracted)
                {
                    Claw.transform.localPosition = Vector2.Lerp(Claw.transform.localPosition, new Vector2(0, -2.3f), 25 * Time.deltaTime);
                    if (Scale)
                        Claw.transform.localScale = Vector2.Lerp(Claw.transform.localScale, Vector3.one, 25 * Time.deltaTime);
                }
                else
                {
                    Claw.transform.localPosition = Vector2.Lerp(Claw.transform.localPosition, Vector2.zero, 25 * Time.deltaTime);
                    if (Scale)
                        Claw.transform.localScale = Vector2.Lerp(Claw.transform.localScale, Vector3.zero, 25 * Time.deltaTime);
                }

                if (Claw.GetComponent<PhysicalBehaviour>().penetrations.Count > 0)
                {
                    Claw.GetComponent<SpriteRenderer>().sortingOrder = OgSortingOrder;
                    Claw.GetComponent<SpriteRenderer>().sortingLayerID = OgSortinglayer;
                }
                else
                {
                    Claw.GetComponent<SpriteRenderer>().sortingOrder = body.GetComponent<SpriteRenderer>().sortingOrder;
                    Claw.GetComponent<SpriteRenderer>().sortingLayerID = body.GetComponent<SpriteRenderer>().sortingLayerID;
                }
            }


        }

        public void ToggleClaw()
        {
            if (Claw != null && CanUse && Enabled)
            {
                if (Retracted)
                {
                    CanUse = false;
                    Claw.SetActive(true);
                    Retracted = false;
                    foreach (var limbs in body.GetComponent<LimbBehaviour>().Person.Limbs)
                    {
                        if (limbs.GetComponent<SlideableHandWeapon>())
                            Physics2D.IgnoreCollision(limbs.GetComponent<SlideableHandWeapon>().Claw.GetComponent<Collider2D>(), Claw.GetComponent<Collider2D>());
                        Physics2D.IgnoreCollision(limbs.GetComponent<Collider2D>(), Claw.GetComponent<Collider2D>());
                    }
                    Component.Destroy(body.GetComponent<FixedJoint2D>());
                    Claw.transform.position = body.transform.position;
                    Claw.transform.localEulerAngles = Vector3.zero;
                    Claw.transform.eulerAngles = new Vector3(Claw.transform.eulerAngles.x, Claw.transform.eulerAngles.y, Claw.transform.eulerAngles.z + 180);
                    body.gameObject.AddComponent<FixedJoint2D>().connectedBody = Claw.GetComponent<Rigidbody2D>();
                    audio.clip = SlideOutSound;
                    Claw.GetComponent<Collider2D>().enabled = true;
                    Claw.GetComponent<PhysicalBehaviour>().InitialMass = 1;
                    Claw.GetComponent<Rigidbody2D>().velocity = -Claw.transform.up * 5;
                    Claw.GetComponent<Rigidbody2D>().centerOfMass = Vector3.zero;
                    audio.Play();
                    StartCoroutine(ExtendClawTimer());
                }
                else
                {
                    CanUse = false;
                    Retracted = true;
                    Claw.GetComponent<Collider2D>().enabled = false;
                    Claw.GetComponent<PhysicalBehaviour>().InitialMass = 0.001f;
                    Claw.GetComponent<Rigidbody2D>().centerOfMass = new Vector2(0, -0.4f);
                    audio.clip = SlideInSound;
                    audio.Play();
                    StartCoroutine(RetractClawTimer());
                }
            }
        }

        private IEnumerator ExtendClawTimer()
        {
            yield return new WaitForSeconds(0.25f);
            CanUse = true;

        }
        private IEnumerator RetractClawTimer()
        {
            yield return new WaitForSeconds(0.25f);
            Claw.SetActive(false);
            CanUse = true;

        }

        public override void DisablePower()
        {
            if (!Retracted)
            {
                CanUse = true;
                ToggleClaw();
            }
           if(eventTrigger)
            eventTrigger.enabled = false;
            if (gameObject.GetComponent<GripBehaviour>())
            {
                gameObject.GetComponent<GripBehaviour>().GripPosition = OgGripPos;
            }
            Enabled = false;
        }

        public override void EnablePower()
        {
            if (eventTrigger)
                eventTrigger.enabled = false;
            if (gameObject.GetComponent<GripBehaviour>())
            {
                gameObject.GetComponent<GripBehaviour>().GripPosition = Vector3.one * 999;
            }
            Enabled = true;
        }

        public override void RemovePower(bool BigDestroy)
        {
            if (CanBeRemoved)
                StartCoroutine(DestroyTimer());
        }

        public override IEnumerator DestroyTimer()
        {
            yield return new WaitForSeconds(0.15f);
            if (body.GetComponent<FixedJoint>())
            {
                Component.Destroy(body.GetComponent<FixedJoint>());
            }
            GameObject.Destroy(Claw);
            if (GetComponent<UseEventTrigger>())
            {
                Component.Destroy(GetComponent<UseEventTrigger>());
            }
            gameObject.GetComponent<GripBehaviour>().GripPosition = OgGripPos;
            Component.Destroy(this);

        }
    }

    }
 }
