using RSBot.Core.Components;

namespace RSBot.Default.Bundle.Attack
{
    internal class AttackBundle : IBundle
    {
        /// <summary>
        /// Merkezi Saldırı Servisi'ni çağırarak saldırı mantığını yürütür.
        /// </summary>
        public void Invoke()
        {
            AttackService.Execute();
        }

        public void Refresh()
        {
            // Bu bundle artık durum (state) tutmadığı için Refresh metodu boştur.
        }

        public void Stop()
        {
            // Bu bundle'ın durdurulduğunda yapması gereken özel bir işlem yoktur.
        }
    }
}
