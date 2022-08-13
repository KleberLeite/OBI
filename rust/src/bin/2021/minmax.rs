fn main() {
    let value = input::read_u16();
    let range = input::read_u16()..=input::read_u16();

    let (mut min, mut max) = (0, 0);

    for num in range {
        if sum_digits(num) == value {
            if min == 0 {
                min = num;
            }

            max = num;
        }
    }

    println!("{min}\n{max}");
}

fn sum_digits(mut num: u16) -> u16 {
    let mut sum = num % 10;

    while num > 0 {
        num /= 10;
        sum += num % 10;
    }

    sum
}
