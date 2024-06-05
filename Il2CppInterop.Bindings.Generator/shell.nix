{
  pkgs ? import <nixpkgs> { },
}:
pkgs.mkShellNoCC {
  shellHook = ''
    export EXTRA_CLANG_ARGS="-isystem ${pkgs.glibc.dev}/include"
  '';
}
