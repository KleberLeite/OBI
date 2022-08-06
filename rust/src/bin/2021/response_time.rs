use std::collections::BTreeMap;

#[derive(Clone, Copy)]
enum Event {
    Receive { friend_id: u8 },
    Respond { friend_id: u8 },
    Sleep { secs: u8 },
}

impl Event {
    fn read() -> Self {
        let (kind, num) = {
            let mut data = input::read();

            (data.remove(0), data[1..].parse().unwrap())
        };

        match kind {
            'R' => Self::Receive { friend_id: num },
            'E' => Self::Respond { friend_id: num },
            'T' => Self::Sleep { secs: num },
            _ => unreachable!(),
        }
    }
}

#[derive(Clone, Copy, Default)]
struct Friend {
    secs: u8,
    responded: bool,
}

impl Friend {
    fn secs(&self) -> i8 {
        if self.responded {
            self.secs as i8
        } else {
            -1
        }
    }
}

fn main() {
    let amount = input::read_u8();
    let mut friends = BTreeMap::new();
    let mut last_event_was_sleep = false;

    for _ in 0..amount {
        match Event::read() {
            Event::Receive { friend_id } => {
                friends
                    .entry(friend_id)
                    .or_insert(Friend::default())
                    .responded = false;

                if !last_event_was_sleep {
                    for (id, friend) in &mut friends {
                        if friend_id != *id && !friend.responded {
                            friend.secs += 1;
                        }
                    }
                }
            }
            Event::Respond { friend_id } => {
                let friend = friends.get_mut(&friend_id).unwrap();
                friend.responded = true;

                if !last_event_was_sleep {
                    friend.secs += 1;

                    for (_, friend) in &mut friends {
                        if !friend.responded {
                            friend.secs += 1;
                        }
                    }
                }
            }
            Event::Sleep { secs } => {
                last_event_was_sleep = true;

                for (_, friend) in &mut friends {
                    friend.secs += secs;
                }

                continue;
            }
        }

        last_event_was_sleep = false;
    }

    for (id, friend) in friends {
        let secs = friend.secs();

        println!("{id} {secs}");
    }
}
