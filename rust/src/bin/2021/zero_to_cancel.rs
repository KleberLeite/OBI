fn main() {
    let amount = input::read_u32();
    let mut nums = Vec::new();

    for _ in 0..amount {
        match input::read_u32() {
            0 => {
                nums.pop();
            }
            num => nums.push(num),
        }
    }

    let sum: u32 = nums.iter().sum();

    println!("{sum}");
}
