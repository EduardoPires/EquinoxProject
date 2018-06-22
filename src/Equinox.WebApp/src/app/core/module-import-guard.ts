// https://angular.io/styleguide#!#04-12
export function throwIfAlreadyLoaded(parentModule: any, moduleName: string) {
  if (parentModule)
    throw new Error(`${moduleName} has already been loaded. Import Core modules in the AppModule only.`);

}
