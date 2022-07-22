{ pkgs ? import <nixpkgs> { } }:
let
    myScript = pkgs.writeScriptBin "foobar" ''
        echo "Foobar" | figlet;
    '';
in pkgs.mkShell {
    name = "MyAwesomeShell";
    buildInputs = with pkgs; [
        figlet
        sqlite
        myScript
    ];

    shellHook = ''
        echo "Welcome to my awesome shell";
    '';
}
