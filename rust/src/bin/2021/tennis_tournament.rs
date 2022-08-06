fn main() {
    let mut wins = 0u8;

    for _ in 0..6 {
        if matches!(input::read_char(), 'V') {
            wins += 1;
        }
    }

    let group: i8 = match wins {
        5..=6 => 1,
        3..=4 => 2,
        1..=2 => 3,
        _ => -1,
    };

    println!("{group}");
}
