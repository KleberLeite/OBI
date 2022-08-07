use std::cmp::Ordering;

fn main() {
    input::read();

    let mut count = 0u32;

    let mut nums: Vec<u32> = input::read()
        .split_whitespace()
        .map(|num| num.parse().unwrap())
        .collect();

    while nums.len() > 1 {
        let first = nums[0];
        let last = nums[nums.len() - 1];

        match first.cmp(&last) {
            Ordering::Equal => {
                nums.remove(0);
                nums.pop();
                continue;
            }
            Ordering::Greater => {
                let sum = nums.pop().unwrap() + nums.pop().unwrap();
                nums.push(sum);
            }
            Ordering::Less => {
                let sum = first + nums.remove(1);
                nums.insert(0, sum);
            }
        }

        count += 1;
    }

    println!("{count}");
}
