fn main() {
    let amount = input::read_u8();
    let mut nums = Vec::new();

    for _ in 0..amount {
        match input::read_u8() {
            0 => {
                nums.pop();
            }
            num => nums.push(num),
        }
    }

    let sum: u8 = nums.iter().sum();

    println!("{sum}");
}
