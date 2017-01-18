using System.Linq;
using System.Collections.Generic;

namespace MindboxJan2017 {
    public class TravelCard {
        public TravelCard(string start, string dst) {
            Start = start;
            Destination = dst;
        }

        public string Start { get; set; }
        public string Destination { get; set; }

        public override bool Equals(object obj) {
            if (obj is TravelCard) {
                var card = obj as TravelCard;
                return this.Start == card.Start && this.Destination == card.Destination;
            }
            return false;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }

    public static class TravelSorter {
        // Оценка сложности алгоритма: в среднем - О(n)
        public static IEnumerable<TravelCard> Sort(IEnumerable<TravelCard> cards) {
            if(cards == null) {
                return null;
            }
            var cardsNumber = cards.Count(); 
            if (cardsNumber <= 1) {
                return cards;
            }
            var hashTable = new Dictionary<string, string>();
            foreach (var card in cards) {
                hashTable.Add(card.Start, card.Destination);
            }

            var sortedCards = new TravelCard[cardsNumber];
            var start = FindStartOfTravel(cards);
            for (var i = 0; hashTable.ContainsKey(start); i++) {
                var destination = hashTable[start];
                sortedCards[i] = new TravelCard(start, destination);
                start = destination;
            }
            return sortedCards;
        }

        public static string FindStartOfTravel(IEnumerable<TravelCard> cards) {
            if (cards == null) {
                return null;
            }
            var hashTable = new Dictionary<string, string>();
            foreach(var card in cards) {
                hashTable.Add(card.Destination, card.Start); // Как бы движение в обратном направлении
            }
            foreach (var item in hashTable) {
                var possibleStart = item.Value; // возможный начальный пункт маршрута
                // если его нет среди ключей, то это действительно начальный пункт
                if (!hashTable.ContainsKey(possibleStart)) {
                    return possibleStart;
                }
            }
            return null;
        }
    }
}
