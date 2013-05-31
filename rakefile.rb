begin
  require 'bundler/setup'
  require 'fuburake'
rescue LoadError
  puts 'Bundler and all the gems need to be installed prior to running this rake script. Installing...'
  system("gem install bundler --source http://rubygems.org")
  sh 'bundle install'
  system("bundle exec rake", *ARGV)
  exit 0
end


@solution = FubuRake::Solution.new do |sln|
	sln.compile = {
		:solutionfile => 'src/FubuMVC.AssetTransforms.sln'
	}
				 
	sln.assembly_info = {
		:product_name => "FubuMVC",
		:copyright => 'Copyright 2011-2013 The FubuMVC team et al. All rights reserved.'
	}
	
	sln.ripple_enabled = true
	sln.fubudocs_enabled = true

	sln.defaults = [:ilrepack]
end


require_relative 'ILRepack'

desc "ILRepack"
task :ilrepack do

  # Coffee ILMerging
  outputDir = "src/FubuMVC.Coffee/bin/#{@solution.compilemode}"
  packer = ILRepack.new :out => "#{outputDir}/FubuMVC.Coffee.dll", :lib => outputDir
  packer.merge :lib => outputDir, :refs => ['FubuMVC.Coffee.dll', 'SassAndCoffee.Core.dll', 'SassAndCoffee.JavaScript.dll']
  
  # Less ILMerging
  outputDir = "src/FubuMVC.Less/bin/#{@solution.compilemode}"
  packer = ILRepack.new :out => "#{outputDir}/FubuMVC.Less.dll", :lib => outputDir
  packer.merge :lib => outputDir, :refs => ['FubuMVC.Less.dll', 'dotless.Core.dll']
end


