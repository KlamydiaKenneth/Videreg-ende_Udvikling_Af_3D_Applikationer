using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon
{
    /// <summary>
    /// The possible elemental types
    /// </summary>
    public enum Elements
    {
        Fire,
        Water,
        Grass
    }

    public class Pokemon
    {
        //fields
        int level;
        int baseAttack;
        int baseDefence;
        float hp;
        float maxHp;
        Elements element;

        //properties, imagine them as private fields with a possible get/set property (accessors)
        //in this case used to allow other objects to read (get) but not write (no set) these variables
        public string Name { get; }
        //example of how to make the string Name readable AND writable  
        //  public string Name { get; set; }
        public List<Move> Moves { get; }
        //can also be used to get/set other private fields
        public float Hp { get => hp; set => hp = maxHp; }
        public float maxHP { get => maxHp; set => hp = maxHp; }

        /// <summary>
        /// Constructor for a Pokemon, the arguments are fairly self-explanatory
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        /// <param name="baseAttack"></param>
        /// <param name="baseDefence"></param>
        /// <param name="hp"></param>
        /// <param name="element"></param>
        /// <param name="moves">This needs to be a List of Move objects</param>
        public Pokemon(string name, string type, int level, int baseAttack,
            int baseDefence, int hp, Elements element,
            List<Move> moves)
        {
            this.level = level;
            this.baseAttack = baseAttack;
            this.baseDefence = baseDefence;
            this.Name = name;
            this.hp = hp * this.level;
            this.maxHp = hp * this.level;
            this.element = element;
            this.Moves = moves;
        }

        /// <summary>
        /// performs an attack and returns total damage, check the slides for how to calculate the damage
        /// IMPORTANT: should also apply the damage to the enemy pokemon
        /// </summary>
        /// <param name="enemy">This is the enemy pokemon that we are attacking</param>
        /// <returns>The amount of damage that was applied so we can print it for the user</returns>
        public float Attack(Pokemon enemy)
        {
            float attackdamage = ((this.baseAttack * this.level)  - enemy.CalculateDefence()) * CalculateElementalEffects(enemy.element);

            //Applying damage to the attacked pokemon.
            if (attackdamage < 1)
            {
                attackdamage = 1;
            }

            enemy.hp -= attackdamage;

            if (enemy.hp < 0)
            {
                enemy.hp = 0;
            }

            return attackdamage;
        }

        /// <summary>
        /// calculate the current amount of defence points
        /// </summary>
        /// <returns> returns the amount of defence points considering the level as well</returns>
        public int CalculateDefence()
        {
            int defence = this.baseDefence * this.level;

            return defence;
        }

        /// <summary>
        /// Calculates elemental effect, check table at https://bulbapedia.bulbagarden.net/wiki/Type#Type_chart for a reference
        /// </summary>
        /// <param name="damage">The amount of pre elemental-effect damage</param>
        /// <param name="enemyType">The elemental type of the enemy</param>
        /// <returns>The damage post elemental-effect</returns>
        /// 
        /// I Could not find the sense in calculating from the pre elemental damage,
        /// since it's a multiplier. So i instead made it in to a simple multiplier
        /// dependant on the enemies and your own pokemons Element.
        public float CalculateElementalEffects(Elements enemyType)
        {
            float elementalMultiplier = 0;

            if (this.element == Elements.Fire)
            {
                if (enemyType == Elements.Fire)
                {

                    elementalMultiplier = 1;
                }
                if (enemyType == Elements.Grass)
                {

                    elementalMultiplier = 2;
                }
                if (enemyType == Elements.Water)
                {

                    elementalMultiplier = .5f;
                }
            }

            else if (this.element == Elements.Water)
            {
                if (enemyType == Elements.Fire)
                {

                    elementalMultiplier = 2;
                }
                if (enemyType == Elements.Grass)
                {

                    elementalMultiplier = .5f;
                }
                if (enemyType == Elements.Water)
                {

                    elementalMultiplier = 1f;
                }
            }

            else if (this.element == Elements.Grass)
            {
                if (enemyType == Elements.Fire)
                {

                    elementalMultiplier = .5f;
                }
                if (enemyType == Elements.Grass)
                {

                    elementalMultiplier = 1;
                }
                if (enemyType == Elements.Water)
                {

                    elementalMultiplier = 2;
                }
            }

            return elementalMultiplier;
        }

        /// <summary>
        /// Applies damage to the pokemon
        /// </summary>
        /// <param name="damage"></param>
        /// This seemed to me like an extra step, that wasnt really important to apply the damage.
        /// instead i applied it in the Attack() function.
        public void ApplyDamage(int damage)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Heals the pokemon by resetting the HP to the max
        /// </summary>
        public void Restore()
        {
            hp = maxHp;
        }
    }
}
