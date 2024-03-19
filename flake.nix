{
  description = "A Nix-flake-based C# development environment";
  
  inputs = 
  {
    nixpkgs.url = "github:NixOS/nixpkgs/nixpkgs-unstable";
    dotnet-5.url = "github:nixos/nixpkgs/2d38b664b4400335086a713a0036aafaa002c003";
  };

  outputs = { self, nixpkgs, ... }@inputs:
    let
        system = "x86_64-darwin";
        pkgs = nixpkgs.legacyPackages.${system};
    in
    {
      devShells.x86_64-darwin.default =
        pkgs.mkShell {
          nativeBuildInputs = with pkgs; [
            dotnet-sdk_6
            #dotnet-sdk_8
            omnisharp-roslyn
            msbuild
            inputs.dotnet-5.legacyPackages.${system}.dotnet-sdk_5
          ];

          shellHook = ''
            echo "hello to csharp dev shell"  
            ${pkgs.dotnet-sdk_6}/bin/dotnet --version
          '';

          OMNISHARP_PATH = "${pkgs.omnisharp-roslyn}/bin/OmniSharp";
        };
    };
}
