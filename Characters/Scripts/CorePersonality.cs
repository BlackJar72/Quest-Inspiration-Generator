using UnityEngine;

public class CorePersonality {
    private const float third10 = 10.0f / 3.0f;

        // Lets make this deep as in OCEAN
        public enum CoreTraits {
            O,
            C,
            E,
            A,
            N
        }

        private int openness, concientiousness, extroversion, agreableness, neuroticism;

        public int O => openness;
        public int C => concientiousness;
        public int E => extroversion;
        public int A => agreableness;
        public int N => neuroticism;


    public CorePersonality() {
        generate();
    }


    public void generate() {
        openness = RollTrait();
        concientiousness = RollTrait();
        extroversion = RollTrait();
        agreableness = RollTrait();
        neuroticism = RollTrait();
    }


    /// <summary>
    /// This will produce a number between 0 and 10 with an average of 5 and a reasonable bell shape without long tails.
    /// </summary>
    /// <returns></returns>
    public int RollTrait() {
        return Mathf.RoundToInt(Random.Range(0.0f, third10) + Random.Range(0.0f, third10) + Random.Range(0.0f, third10));
    }


    public int GetTrait(CoreTraits t) {
        return t switch
        {
            CoreTraits.O => O,
            CoreTraits.C => C,
            CoreTraits.E => E,
            CoreTraits.A => A,
            CoreTraits.N => N,
            _ => throw new System.Exception("Was passed non-existed enum constant!  Is that even possible!!!"),
        };
    } 


    public int ModTrait(CoreTraits t, int amount) {
        return t switch
        {
            CoreTraits.O => openness = Mathf.Clamp(openness + amount, 0, 10),
            CoreTraits.C => concientiousness = Mathf.Clamp(concientiousness + amount, 0, 10),
            CoreTraits.E => extroversion = Mathf.Clamp(extroversion + amount, 0, 10),
            CoreTraits.A => agreableness = Mathf.Clamp(agreableness + amount, 0, 10),
            CoreTraits.N => neuroticism = Mathf.Clamp(neuroticism + amount, 0, 10),
            _ => throw new System.Exception("Was passed non-existed enum constant!  Is that even possible!!!"),
        };
    } 


    public bool IsCompatible(PersonalityTrait t) {
        bool result = true;
        foreach(PersonalityTrait.Requiremnt req in t.Reqs) {
            if(req.LessThan) result = result && IsLowEnough(req);
            else result = result && IsHighEnough(req);
            if(!result) return false;
        }
        return true;
    }


    private bool IsHighEnough(PersonalityTrait.Requiremnt req) {
        return req.Trait switch {
            CoreTraits.O => openness         >= req.Value,
            CoreTraits.C => concientiousness >= req.Value,
            CoreTraits.E => extroversion     >= req.Value,
            CoreTraits.A => agreableness     >= req.Value,
            CoreTraits.N => neuroticism      >= req.Value,
            _ => throw new System.Exception("Was passed non-existed enum constant!  Is that even possible!!!"),
        };
    }


    private bool IsLowEnough(PersonalityTrait.Requiremnt req) {
        return req.Trait switch {
            CoreTraits.O => openness         <= req.Value,
            CoreTraits.C => concientiousness <= req.Value,
            CoreTraits.E => extroversion     <= req.Value,
            CoreTraits.A => agreableness     <= req.Value,
            CoreTraits.N => neuroticism      <= req.Value,
            _ => throw new System.Exception("Was passed non-existed enum constant!  Is that even possible!!!"),
        };
    }

}
