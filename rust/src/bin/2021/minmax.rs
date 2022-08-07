fn main() {
    let value = input::read_u16();
    let range = input::read_u16()..=input::read_u16();

    let mut min = None;
    let mut max = 0;

    for num in range {
        let sum = sum_digits(num);

        if sum == value {
            if min.is_none() {
                min = Some(num);
            }

            max = num;
        }
    }

    println!("{}\n{max}", min.unwrap());
}

fn sum_digits(mut num: u16) -> u16 {
    let mut sum = 0;

    while num != 0 {
        sum += num % 10;
        num /= 10;
    }

    sum
}
