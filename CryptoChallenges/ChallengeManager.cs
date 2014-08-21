using System;
using System.Collections.Generic;
using System.Reflection;

namespace CryptoChallenges {
    public class ChallengeManager {
        private Dictionary<char, Action> challenges;
        private readonly Set1Challenges set1Challenges;

        public ChallengeManager() {
            set1Challenges = new Set1Challenges();
            InitAvailableChallenges();
        }

        public void RunChallenge(char challenge) {
            if (!challenges.ContainsKey(challenge))
                Console.WriteLine("Challenge {0} not implemented", challenge);
            else
                challenges[challenge]();
        }

        private void InitAvailableChallenges() {
            challenges = new Dictionary<char, Action>();
            MethodInfo[] methodInfos = typeof(Set1Challenges).GetMethods(BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance);


            for (int i = 0; i < methodInfos.Length; i++) {
                challenges.Add(char.Parse((i + 1).ToString()), (Action)methodInfos[i].CreateDelegate(typeof(Action), set1Challenges));
            }
        }
    }
}
