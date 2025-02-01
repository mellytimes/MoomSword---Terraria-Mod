using System.Threading;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace FunniMod.Content.Projectiles
{
    internal class FunniSwordProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 0;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 10;
            Projectile.timeLeft = 720;
            Projectile.light = 0.1f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 0;
            Projectile.owner = Main.myPlayer;
            Main.NewText($"Projectile Owner: {Projectile.owner}, Position: {Projectile.position}");
        }

        public override void AI()
        {
            Projectile.ai[0] += 1f;
            if (Projectile.ai[0] % 20 == 0 && Projectile.ai[0] < 200)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, ProjectileID.CursedFlameFriendly, 20, 7);
            }

        }
        public override void ModifyHitPlayer(Player target, ref Player.HurtModifiers modifiers)
        {
            if (target == Main.player[Projectile.owner]) // Prevents self-damage
            {
                modifiers.FinalDamage *= 0; // No damage to the owner
            }
        }

    }
}
