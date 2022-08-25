use std::collections::HashMap;

fn main() {
    input::read();

    let data = input::read();
    let len = data.len();
    let mut root = None;

    for i in 2..=len {
        if len % i != 0 {
            continue;
        }

        let amount = len / i;
        root = Some(&data[..amount]);

        let root_char_count = char_count(root.unwrap());

        for j in 0..i {
            let word = &data[j * amount..(j + 1) * amount];

            if char_count(word) != root_char_count {
                root = None;
            }
        }

        if root.is_some() {
            break;
        }
    }

    let root = root.unwrap_or("*");

    println!("{root}");
}

fn char_count(word: &str) -> HashMap<char, u8> {
    let mut count = HashMap::new();

    for char in word.chars() {
        *count.entry(char).or_default() += 1;
    }

    count
}
