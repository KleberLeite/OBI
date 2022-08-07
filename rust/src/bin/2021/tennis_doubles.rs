use input::read_u16;

fn main() {
    let players = [read_u16(), read_u16(), read_u16(), read_u16()];

    let first_team_level = players[0] + players[3];
    let second_team_level = players[1] + players[2];

    let level_difference = first_team_level - second_team_level;

    println!("{level_difference}");
}
