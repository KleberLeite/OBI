use std::{
    collections::HashSet,
    fmt::{Display, Formatter, Result},
};

#[derive(Default)]
struct Naipe {
    cards: HashSet<u8>,
    repeated: bool,
}

impl Display for Naipe {
    fn fmt(&self, f: &mut Formatter) -> Result {
        if self.repeated {
            write!(f, "erro")
        } else {
            write!(f, "{}", 13 - self.cards.len())
        }
    }
}

#[derive(Default)]
struct Deck {
    clubs: Naipe,
    diamonds: Naipe,
    hearts: Naipe,
    spades: Naipe,
}

fn main() {
    let mut deck = Deck::default();
    let mut data = &input::read()[..];

    while !data.is_empty() {
        let card = data[..2].parse::<u8>().unwrap();

        let naipe = match &data[2..3] {
            "P" => &mut deck.clubs,
            "U" => &mut deck.diamonds,
            "C" => &mut deck.hearts,
            "E" => &mut deck.spades,
            _ => unreachable!(),
        };

        if !naipe.repeated {
            naipe.repeated = !naipe.cards.insert(card);
        }

        data = &data[3..];
    }

    let Deck {
        clubs,
        diamonds,
        hearts,
        spades,
    } = deck;

    println!("{hearts}\n{spades}\n{diamonds}\n{clubs}");
}
