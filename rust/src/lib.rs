pub fn read() -> String {
    let mut buf = String::new();
    std::io::stdin().read_line(&mut buf).unwrap();
    buf.trim_end().into()
}

pub fn read_u8() -> u8 {
    read().parse().unwrap()
}

pub fn read_u16() -> u16 {
    read().parse().unwrap()
}

pub fn read_u32() -> u32 {
    read().parse().unwrap()
}

pub fn read_char() -> char {
    read().remove(0)
}
