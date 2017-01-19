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
            TravelCard card = obj as TravelCard;
            return card != null ? Start == card.Start && Destination == card.Destination : false;
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }

    public static class TravelSorter {
        // Оценка сложности алгоритма: в среднем - О(n), в худшем - O(n^2)
        public static IEnumerable<TravelCard> Sort(IEnumerable<TravelCard> cards) {
            if(cards == null) {
                return null;
            }
            var cardsNumber = cards.Count(); 
            if (cardsNumber <= 1) {
                return cards;
            }
            var moves = new Dictionary<string, string>();
            foreach (var card in cards) {
                moves.Add(card.Start, card.Destination);
            }

            var sortedCards = new TravelCard[cardsNumber];
            var start = FindStartOfTravel(cards);
            for (var i = 0; moves.ContainsKey(start); i++) {
                var destination = moves[start];
                sortedCards[i] = new TravelCard(start, destination);
                start = destination;
            }
            return sortedCards;
        }

        public static string FindStartOfTravel(IEnumerable<TravelCard> cards) {
            if (cards == null) {
                return null;
            }
            var reverseMoves = new Dictionary<string, string>();
            foreach(var card in cards) {
                reverseMoves.Add(card.Destination, card.Start); // Как бы движение в обратном направлении
            }
            foreach (var item in reverseMoves) {
                var possibleStart = item.Value; // возможный начальный пункт маршрута
                // если его нет среди ключей, то это действительно начальный пункт
                if (!reverseMoves.ContainsKey(possibleStart)) {
                    return possibleStart;
                }
            }
            return null;
        }
    }
}
